using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ClickerHandler : MonoBehaviour {

	public Text TotalCoins, perSecText;
	public Int64  perSecValue;
	public Int64 TotalCoinsValue;

	public float updateTime;
	float secCounter;

	public shopHandler ShopHandler;
	void Start(){
		TotalCoins.text = "0 gold";
	}


	// Update is called once per frame
	void Update () {
		TotalCoins.text = TotalCoinsValue.ToString("D") + " gold";
		perSecIncome ();
		if (secCounter < updateTime) {
			secCounter += Time.deltaTime;
		} else {
			secCounter = 0;
			TotalCoinsValue += Convert.ToInt64(Mathf.RoundToInt(Convert.ToSingle (perSecValue) * updateTime));
			PlayerPrefs.SetString ("TotalCoins", TotalCoinsValue.ToString("D"));
		}

	}

	void perSecIncome(){
		Int64 sum = 0;
		foreach (shopHandler.Item item in ShopHandler.shopItems) {
			if (item.piece != 0) sum += item.baseValue * Mathf.RoundToInt (Mathf.Pow (1.2f, Convert.ToUInt64(item.piece)));
		}
		perSecValue = sum;
	}


}
