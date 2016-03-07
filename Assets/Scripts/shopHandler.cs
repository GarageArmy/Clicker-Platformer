using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Globalization;
using System;
public class shopHandler : MonoBehaviour {

[System.Serializable]
	public class Item {
		public string name;
		public Int64 cost, effect;
		public int piece;
		public Int64 baseValue;
		public Sprite image;

	}
	int active1 = 0;
	public ClickerHandler clickHandling;
	public GameObject[] buttonItems;
	public Item[] shopItems;
	public GameObject button;
	public PanelController panelController;
	void Start(){
		resetAllSaves(); //
		LoadDatas ();
		buttonItems = new GameObject[shopItems.Length];
		int number = 0;
		foreach (Item i in shopItems) {

			GameObject thingy = (GameObject)Instantiate (button);
			buttonItems [number] = thingy;
			ItemInfos scp = thingy.GetComponent<ItemInfos>();
			scp.name.text = i.name;
			scp.cost.text = "Cost: " + i.cost.ToString("D");
			scp.effect.text = i.effect.ToString("D");
			scp.pieces.text = i.piece.ToString("D");
			scp.icon.sprite = i.image;
			thingy.transform.SetParent (this.transform);

			Item thisItem = i;
			scp.thisButton.onClick.AddListener ( () => Purchase (thisItem));
			number++;
		}
		int n = 0;
		foreach (Item i in shopItems) {
			buttonItems [n].SetActive (false);
			n++;
	}

	}

	void Purchase (Item wannaBought){
		if (clickHandling.TotalCoinsValue >= wannaBought.cost){
		clickHandling.TotalCoinsValue -= wannaBought.cost;
			wannaBought.cost = Mathf.RoundToInt (1.2f * wannaBought.cost);
			wannaBought.effect = Mathf.RoundToInt (wannaBought.effect * 1.2f);
			wannaBought.piece++;
			if (wannaBought.effect == Mathf.RoundToInt (wannaBought.effect * 1.2f))
				wannaBought.effect++;
		UpdateItem ();
			}
		}

	void UpdateItem(){
		int number = 0;
		foreach (Item i in shopItems) {
			ItemInfos scp = buttonItems [number].GetComponent<ItemInfos> ();
			scp.cost.text = "Cost: " + i.cost.ToString ("D");
			scp.effect.text = i.effect.ToString ("D");
			scp.pieces.text = i.piece.ToString ("D");
			PlayerPrefs.SetInt (i.name + "piece", i.piece);
			PlayerPrefs.SetString (i.name + "cost", i.cost.ToString("D"));
			PlayerPrefs.SetString (i.name + "effect", i.effect.ToString("D"));
			number++;
		}
	}

	void Update (){
		int n = 0;
		foreach (Item i in shopItems){
			if (clickHandling.TotalCoinsValue >= i.cost) {
				buttonItems [n].SetActive (true);
				//active1++;
				//panelController.PanelPadding (active1, "ShopHandler");
				buttonItems [n].GetComponent<Button> ().interactable = true;
			}
			else buttonItems [n].GetComponent<Button> ().interactable = false;
			n++;
			}
			Debug.Log(active1);
	}

	public void LoadDatas (){
		clickHandling.TotalCoinsValue = PlayerPrefs.GetInt ("TotalCoins");
		int n = 0;
		foreach (Item i in shopItems) {
			i.piece = PlayerPrefs.GetInt (i.name + "piece", i.piece);
			i.cost = Convert.ToInt64 (PlayerPrefs.GetString (i.name + "cost", i.cost.ToString("D")));
			i.effect = Convert.ToInt64(PlayerPrefs.GetString (i.name + "effect", i.effect.ToString("D")));
			n++;
		}
	}

	public void resetAllSaves(){
		PlayerPrefs.DeleteAll ();
	}
}
