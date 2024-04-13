/*
 * User: Doebbel
 * Date: 24.01.2024
 * Time: 14:31
 */
using System;

namespace SSP_Enums
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Game
	{
		ConsoleKeyInfo cki;
		
		Items player = new Items();
		Items enemy = new Items();
		Random enRnd = new Random();
		
		int draw;
		int wins;
		int loses;
		
		public Game()
		{
			GameLoop();
		}

		int userInput = -1;
		int enCalc;
		
		string input;
		
		enum Items
		{
			None = 0,
			Schere = 1,
			Stein = 2,		// erkennt die Nummerierung nach erstem Definieren!
			Papier = 3
		}
		
		private void GameLoop(){
			while(true){
				CalcForNextRound();
				ItemOutput();
				GetUserInput();
				EnRnd();
				enemy = EnChoice(enCalc);
				player = UserChoice(userInput);
				CalcWinner(player, enemy);
				Console.ReadLine();
			}
		}
		
		private void ItemOutput(){
			Console.Write("Wähle dein Objekt: 1. " + Items.Schere + ", 2. " + Items.Stein + ", 3. " + Items.Papier + " ");
		}
		
		private int GetUserInput(){
			while(true){
				input = Console.ReadLine();
				
				if(!Int32.TryParse(input, out userInput)){
					Console.WriteLine("Invalid Input!");
				}
				else{
					break;
				}
			}
			return userInput;
		}
		
		private void EnRnd(){
			enCalc = enRnd.Next(1, 4);
		}
		
		private Items EnChoice(int enCalc)
		{
			switch(enCalc){
				case 1:
					return Items.Schere;
					
				case 2:
					return Items.Stein;
					
				case 3:
					return Items.Papier;
				default:
					return Items.None;
			}
		}
		
		private Items UserChoice(int userInput){
			
			switch(userInput){
				case 1:
					return Items.Schere;
					
				case 2:
					return Items.Stein;
					
				case 3:
					return Items.Papier;
				default:
					return Items.None;
			}
		}
		
		private void CalcWinner(Items player, Items enemy){
			if(player == Items.Papier && enemy == Items.Papier || player == Items.Schere && enemy == Items.Schere || player == Items.Stein && enemy == Items.Stein){
				Console.WriteLine("Gleichstand bei gleichen Objekten!");
				draw++;
			}
			else if(player == Items.Schere && enemy == Items.Stein || player == Items.Papier && enemy == Items.Schere || player == Items.Stein && enemy == Items.Papier){
				Console.WriteLine("Spieler hat verloren! Gegner spielte Objekt: " + enemy);
				loses++;
			}
			else if(player == Items.Stein && enemy == Items.Schere || player == Items.Schere && enemy == Items.Papier || player == Items.Papier && enemy == Items.Stein){
				Console.WriteLine("Spieler hat gewonnen! Gegner spielte Objekt: " + enemy);
				wins++;
			}
		}
		
		private void CalcForNextRound(){
			if(draw > 0 || wins > 0 || loses > 0){
				Console.Clear();
				float maxRounds = wins + draw + loses;
				float winPerc = (float)wins/maxRounds*100;
				float drawPerc = (float)draw/maxRounds*100;
				float losePerc = (float)loses/maxRounds*100;
				
				Console.WriteLine("Siege: {0} = {1:F2}%, Gleichstand: {2} = {3:F2}%, Niederlagen: {4} = {5:F2}%", wins, winPerc, draw, drawPerc, loses, losePerc);
				Console.WriteLine("Runden insgesamt: " + maxRounds);
				Console.WriteLine();
			}
		}
	}
}
