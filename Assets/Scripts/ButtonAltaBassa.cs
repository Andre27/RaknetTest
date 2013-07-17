using UnityEngine;
using System.Collections;

public class ButtonAltaBassa : MonoBehaviour
{

	void OnClick ()
	{
		if (Main.turno == Main.Turno.TURNO1 || Main.turno == Main.Turno.TURNO2) {
			switch (this.transform.name) {
			case "Alta 1":
				Main.player1.scelta = Player.Scelta.ALTA;
				break;
			case "Alta 2":
				Main.player2.scelta = Player.Scelta.ALTA;
				break;
			case "Bassa 1":
				Main.player1.scelta = Player.Scelta.BASSA;
				break;
			case "Bassa 2":
				Main.player2.scelta = Player.Scelta.BASSA;
				break;
			default:
				break;
			}
		} else {
			Main.turno = Main.Turno.INIZIOGIOCO;
		}
	}
}
