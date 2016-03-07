using UnityEngine;
using System.Collections;
using System.Threading;
using System.Text;

public class CoinConverter : MonoBehaviour {
    public ClickerHandler cH;
    string[] suffix = {"K", "M", "B", "T", ""};


	public string sumStrings(string a, string b){
		char[] num1 = a.ToCharArray();
		char[] num2 = b.ToCharArray();

			int i = num1.Length - 1;
			int j = num2.Length - 1;

			StringBuilder sumString = new StringBuilder();
			int carry = 0;

			while(i >= 0 || j >= 0){
				int d1 = 0;
				int d2 = 0;

				if (i >= 0) d1 = num1[i--] - '0';
				if (j >= 0) d2 = num2[j--] - '0';

				int sum = d1 + d2 + carry;
				if (sum >= 10){
					carry = sum / 10;
					sum = sum % 10;
				}else carry = 0;

				sumString.Insert(0, sum);
			}
			return sumString.ToString();
	}

		//////////////////


}
