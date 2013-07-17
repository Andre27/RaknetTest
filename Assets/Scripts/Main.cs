using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
	public  CardAtlas atlas;
	public  CardStock stock;
	int initialCard;
	public Card card;
	public enum Turno
	{
		TURNO1,
		TURNO2,
		FINEGIOCO,
		INIZIOGIOCO
	};
	public static Turno turno;
	public static GameObject turnoLabel;
	public static GameObject alta1;
	public static GameObject alta2;
	public static GameObject bassa1;
	public static GameObject bassa2;
	public static Player player1;
	public static Player player2;
	
	// Use this for initialization
	void Start ()
	{
		turno = Turno.INIZIOGIOCO;
		turnoLabel = GameObject.Find ("Turno");
		bassa1 = GameObject.Find ("Bassa 1");
		bassa2 = GameObject.Find ("Bassa 2");
		alta1 = GameObject.Find ("Alta 1");
		alta2 = GameObject.Find ("Alta 2");
		card = GameObject.Find ("Card").GetComponent<Card> ();
		player1 = GameObject.Find ("Player1").GetComponent<Player> ();
		player2 = GameObject.Find ("Player2").GetComponent<Player> ();
		player1.behaviour = Player.Behaviour.HUMAN;
		player2.behaviour = Player.Behaviour.HUMAN;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		switch (turno) {
		case Turno.INIZIOGIOCO:
			System.Random r = new System.Random ();
			initialCard = r.Next (40);
			drawCard (card, initialCard);
			turno = Turno.TURNO1;
			break;
		case Turno.TURNO1:
			if (player1.behaviour == Player.Behaviour.HUMAN) {
				NGUITools.SetActive (bassa1, true);
				NGUITools.SetActive (alta1, true);
			}
			NGUITools.SetActive (bassa2, false);
			NGUITools.SetActive (alta2, false);
			turnoLabel.GetComponent<UILabel> ().text = "TURNO 1";
			switch (player1.scelta) {
			case Player.Scelta.ALTA:
				System.Random r1 = new System.Random ();
				int newCard = r1.Next (40);
				drawCard (card, newCard);
				if (newCard % 10 >= initialCard % 10) {
					turno = Turno.TURNO2;
					initialCard = newCard;
				} else {
					turno = Turno.FINEGIOCO;
				}
				player1.scelta = Player.Scelta.ATTESA;
				break;
			case Player.Scelta.BASSA:
				System.Random r2 = new System.Random ();
				int newCard2 = r2.Next (40);
				drawCard (card, newCard2);
				if (newCard2 % 10 <= initialCard % 10) {
					turno = Turno.TURNO2;
					initialCard = newCard2;
				} else {
					turno = Turno.FINEGIOCO;
				}
				player1.scelta = Player.Scelta.ATTESA;
				break;
			default:
				break;
			}
			break;
		case Turno.TURNO2:
			if (player2.behaviour == Player.Behaviour.HUMAN) {
				NGUITools.SetActive (bassa2, true);
				NGUITools.SetActive (alta2, true);
			}
			NGUITools.SetActive (bassa1, false);
			NGUITools.SetActive (alta1, false);
			turnoLabel.GetComponent<UILabel> ().text = "TURNO 2";
			switch (player2.scelta) {
			case Player.Scelta.ALTA:
				System.Random r1 = new System.Random ();
				int newCard = r1.Next (40);
				drawCard (card, newCard);
				if (newCard % 10 >= initialCard % 10) {
					turno = Turno.TURNO1;
					initialCard = newCard;
				} else {
					turno = Turno.FINEGIOCO;
				}
				player1.scelta = Player.Scelta.ATTESA;
				break;
			case Player.Scelta.BASSA:
				System.Random r2 = new System.Random ();
				int newCard2 = r2.Next (40);
				drawCard (card, newCard2);
				if (newCard2 % 10 <= initialCard % 10) {
					turno = Turno.TURNO1;
					initialCard = newCard2;
				} else {
					turno = Turno.FINEGIOCO;
				}
				player2.scelta = Player.Scelta.ATTESA;
				break;
			default:
				break;
			}
			break;
		case Turno.FINEGIOCO:
			turnoLabel.GetComponent<UILabel> ().text = "HAI PERSO";
			break;
		default:
			break;
		}
	}
	
	public void drawCard (Card cardDest, int cardSource)
	{
		string symbol;
		string text;
		int pattern;
		string [] prefixes = new string[]{"H-","D-","C-","S-"};
		string prefix = "";
		
		switch (cardSource / 10) {
		case 0:
			symbol = "Heart";
			prefix = prefixes [0];
			break;
		case 1:
			symbol = "Diamond";
			prefix = prefixes [1];
			break;
		case 2:
			symbol = "Club";
			prefix = prefixes [2];
			break;
		case 3:
			symbol = "Spade";
			prefix = prefixes [3];
			break;
		default:
			symbol = "Heart";
			break;
		}
			
		switch (cardSource % 10) {		
		case 0:
			text = "K"; 
			pattern = 0;
			break;
		case 9:
			text = "Q"; 
			pattern = 0;				
			break;
		case 8:
			text = "J"; 
			pattern = 0;
			break;
		case 7:
			text = "7"; 
			pattern = 7;
			break;
		case 6:
			text = "6"; 
			pattern = 6;
			break;
		case 5:
			text = "5"; 
			pattern = 5;
			break;
		case 4:
			text = "4"; 
			pattern = 4;
			break;
		case 3:
			text = "3"; 
			pattern = 3;
			break;
		case 2:
			text = "2"; 
			pattern = 2;
			break;
		case 1:
			text = "A"; 
			pattern = 1;
			break;
		default:
			text = "1"; 
			pattern = 0;
			break;
		}
			
			
		CardDef cd = new CardDef (atlas, stock, text, symbol, pattern);
			
		switch (text) {
		case "J":
			cd.Image = prefix + "Jack";
			break;
		case "Q":
			cd.Image = prefix + "Queen";
			break;
		case "K":
			cd.Image = prefix + "King";
			break;
		default:
			break;
		}
		cardDest.Definition = cd; 
		cardDest.Rebuild ();
	}
}
