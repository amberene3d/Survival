using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Survivors {
	public class Survivor {
		public string firstName;
		public string lastName;

		public string sex;

		public int age;

		public List<string> traits;

		// meters
		public int health;
		public int happiness;

		// skills
		public Dictionary<string, int> skills;
	}
}
