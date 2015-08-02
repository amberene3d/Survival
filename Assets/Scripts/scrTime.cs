using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class scrTime : MonoBehaviour {

	public int years, months, days;
	public Text dateLabel;
	
	/*** Game Loop Functions ***/
	void Start () {
		LoadTime ();
		if (years == 0) {
			AddTime (1, 1, 1);
			SaveTime ();
		}
		ShowTime ();
	}
	
	/*** Other Functions ***/
	// days, months, years
	void AddTime(int d = 0, int m = 0, int y = 0) {
		int mlength = 31;
		// 30 days has September, April, June, and November
		if (months == 4 || months == 6 || months == 9 || months == 11) {
			mlength = 30;
		} else if (months == 2) {
			// Leap year, bitches!
			if(years % 4 == 0)
				mlength = 29;
			else
				mlength = 28;
		}

		if (days + d > mlength) {
			days = days + d - mlength;
			m++;
		} else {
			days += d;
		}
		
		if (months + m > 11) {
			months = months + m - 11;
			y++;
		} else {
			months += m;
		}
		
		years += y;
		ShowTime ();
	}

	/*** Save/Load Time ***/
	void LoadTime() {
		years = PlayerPrefs.GetInt ("years");
		months = PlayerPrefs.GetInt ("months");
		days = PlayerPrefs.GetInt ("days");
	}
	
	void SaveTime() {
		PlayerPrefs.SetInt ("years", years);
		PlayerPrefs.SetInt ("months", months);
		PlayerPrefs.SetInt ("days", days);
	}
	
	void ClearTime() {
		PlayerPrefs.DeleteKey ("years");
		PlayerPrefs.DeleteKey ("months");
		PlayerPrefs.DeleteKey ("days");
	}
	
	/*** Time UI ***/
	void ShowTime() {
		string m = "";
		string s = "";
		switch (months) {
		case 1:
			m = "January";
			s = "Winter";
			break;
		case 2:
			m = "February";
			s = "Winter";
			break;
		case 3:
			m = "March";
			if(days > 20)
				s = "Spring";
			else 
				s = "Winter";
			break;
		case 4:
			m = "April";
			s = "Spring";
			break;
		case 5:
			m = "May";
			s = "Spring";
			break;
		case 6:
			m = "June";
			if(days > 20)
				s = "Summer";
			else 
				s = "Spring";
			break;
		case 7:
			m = "July";
			s = "Summer";
			break;
		case 8:
			m = "August";
			s = "Summer";
			break;
		case 9:
			m = "September";
			if(days > 20)
				s = "Autumn";
			else 
				s = "Summer";
			break;
		case 10:
			m = "October";
			s = "Autumn";
			break;
		case 11:
			m = "November";
			s = "Autumn";
			break;
		case 12:
			m = "December";
			if(days > 20)
				s = "Winter";
			else 
				s = "Autumn";
			break;
		}
		dateLabel.text = "Year " + years.ToString () + ", " + days.ToString () + " " + m + " (" + s + ")";
	}

	public void NextDay() {
		AddTime (1);
	}

/************ WITH HOURS ****************/
//	public int years, months, days, hours;
//	public Text timeLabel, dateLabel;
//
//	/*** Game Loop Functions ***/
//	void Start () {
//		LoadTime ();
//		if (years == 0) {
//			AddTime (12, 1, 1, 1);
//			SaveTime ();
//		}
//		ShowTime ();
//	}
//
//	/*** Other Functions ***/
//	// hours, days, months, years
//	void AddTime(int h = 0, int d = 0, int m = 0, int y = 0) {
//		if (hours + h > 23) {
//			hours = hours + h - 24;
//			d++;
//		} else {
//			hours += h;
//		}
//
//		if (days + d > 30) {
//			days = days + d - 30;
//			m++;
//		} else {
//			days += d;
//		}
//
//		if (months + m > 11) {
//			months = months + m - 11;
//			y++;
//		} else {
//			months += m;
//		}
//
//		years += y;
//	}
//
//	/*** Save/Load Time ***/
//	void LoadTime() {
//		years = PlayerPrefs.GetInt ("years");
//		months = PlayerPrefs.GetInt ("months");
//		days = PlayerPrefs.GetInt ("days");
//		hours = PlayerPrefs.GetInt ("hours");
//	}
//
//	void SaveTime() {
//		PlayerPrefs.SetInt ("years", years);
//		PlayerPrefs.SetInt ("months", months);
//		PlayerPrefs.SetInt ("days", days);
//		PlayerPrefs.SetInt ("hours", hours);
//	}
//
//	void ClearTime() {
//		PlayerPrefs.DeleteKey ("years");
//		PlayerPrefs.DeleteKey ("months");
//		PlayerPrefs.DeleteKey ("days");
//		PlayerPrefs.DeleteKey ("hours");
//	}
//
//	/*** Time UI ***/
//	void ShowTime() {
//		timeLabel.text = hours.ToString () + ":00";
//		string m = "";
//		string s = "";
//		switch (months) {
//		case 1:
//			m = "January";
//			s = "Winter";
//			break;
//		case 2:
//			m = "February";
//			s = "Winter";
//			break;
//		case 3:
//			m = "March";
//			if(days > 20)
//				s = "Spring";
//			else 
//				s = "Winter";
//			break;
//		case 4:
//			m = "April";
//			s = "Spring";
//			break;
//		case 5:
//			m = "May";
//			s = "Spring";
//			break;
//		case 6:
//			m = "June";
//			if(days > 20)
//				s = "Summer";
//			else 
//				s = "Spring";
//			break;
//		case 7:
//			m = "July";
//			s = "Summer";
//			break;
//		case 8:
//			m = "August";
//			s = "Summer";
//			break;
//		case 9:
//			m = "September";
//			if(days > 20)
//				s = "Autumn";
//			else 
//				s = "Summer";
//			break;
//		case 10:
//			m = "October";
//			s = "Autumn";
//			break;
//		case 11:
//			m = "November";
//			s = "Autumn";
//			break;
//		case 12:
//			m = "December";
//			if(days > 20)
//				s = "Winter";
//			else 
//				s = "Autumn";
//			break;
//		}
//		dateLabel.text = "Year " + years.ToString () + ", " + days.ToString () + " " + m + " (" + s + ")";
//	}
}
