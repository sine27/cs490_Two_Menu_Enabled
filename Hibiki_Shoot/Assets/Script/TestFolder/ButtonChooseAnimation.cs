using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ButtonChooseAnimation : MonoBehaviour {

    // Definition
    int CONDITION_TRANS_POS = 1;
    int CONDITION_BUTTON_POS = 11;
    int CONDITION_HUNGER = 111;
    int CONDITION_HAPPY = 112;
    int CONDITION_CLEAN = 113;
    int CONDITION_HEALTH = 114;

    int SHOP_TRANS_POS = 2;
    int SHOP_BUTTON_POS = 21;
    int SHOP_FOOD = 211;
    int SHOP_TOY = 212;
    int SHOP_COM = 213;

	int SHOP_FOOD_DONUT = 221;
	int SHOP_FOOD_BURGER = 231;
	int SHOP_FOOD_MILK = 241;
	int SHOP_TOY_BALL = 222;
	int SHOP_COM_TOWEL = 223;
	int SHOP_COM_MED = 233;

	// >>>>> Sine >>>>>
	// Inventory Field
	int INVEN_TRANS_POS = 3;
	int INVEN_BUTTON_POS = 31;
	int INVEN_BURGER = 311;
	int INVEN_DONUTS = 312;
	int INVEN_MILK = 313;
	int INVEN_BALL = 314;
	int INVEN_TOWEL = 315;
	int INVEN_MEDI = 316;
	// <<<<< Sine <<<<<

    // Common-Use Field

    [SerializeField]
    private GameObject cursor;

    [SerializeField]
    private GameObject ball;

    // Common-Use variables

    private int counter;
    private float fillAmount = 0.0f;
    private int kwidth = Screen.width;
    private int kheight = Screen.height;
    private float distanceToCamera = 10f;
    private Image currMask = null;
    private Transform currTrans = null;


    // Special-Use Field

    [SerializeField]
    private GameObject conditionBtn;

    [SerializeField]
    private Image conditionMask;

    [SerializeField]
    private Image hungerMask;

    [SerializeField]
    private Image happyMask;

    [SerializeField]
    private Image cleanMask;

    [SerializeField]
    private Image healthMask;

    public Transform conditionTransform;
    public Transform hungerTransform;
    public Transform happyTransform;
    public Transform cleanTransform;
    public Transform healthTransform;
    private bool conditionActive = false;


    [SerializeField]
    private GameObject shopBtn;

    [SerializeField]
    private Image shopMask;

    [SerializeField]
    private Image foodMask;

    [SerializeField]
    private Image toyMask;

    [SerializeField]
    private Image commMask;

	[SerializeField]
	private Image shopDonutsMask;

	[SerializeField]
	private Image shopBurgerMask;

	[SerializeField]
	private Image shopMilkMask;

	[SerializeField]
	private Image shopBallMask;

	[SerializeField]
	private Image shopTowelMask;

	[SerializeField]
	private Image shopMediMask;

    public Transform shopTransform;
    public Transform foodTransform;
    public Transform toyTransform;
    public Transform commTransform;
    private bool shopActive = false;
	private bool foodActive = false;
	private bool toyActive = false;
	private bool commActive = false;


	// >>>>> Sine >>>>>
	// Inventory Field
	[SerializeField]
	private GameObject inventoryBtn;

	[SerializeField]
	private Image inventoryMask;

	[SerializeField]
	private Image burgerMask;

	[SerializeField]
	private Image donutsMask;

	[SerializeField]
	private Image milkMask;

	[SerializeField]
	private Image ballMask;

	[SerializeField]
	private Image towelMask;

	[SerializeField]
	private Image mediMask;

	public Transform inventoryTransform;
	public GameObject burgerObject;
	public GameObject donutsObject;
	public GameObject milkObject;
	public GameObject ballObject;
	public GameObject towelObject;
	public GameObject mediObject;
	private bool inventoryActive = false;
	// <<<<< Sine <<<<<


    public bool isInventory = false;

    // Use this for initialization
    void Start () {
        counter = 0;
        fillAmount = 0.0f;
        cursor.transform.position = new Vector2(Screen.width/2, Screen.height/2);
    }
	
	// Update is called once per frame
	void Update () {
        cursor.transform.position = kinectToReal(ball.transform.position);
        int cursorPos = isCursorEnter();
        // CONDITION BUTTON
        if (cursorPos == CONDITION_BUTTON_POS)
        {
            actMouseAnim(conditionMask, conditionTransform);
        }
        else if (conditionActive)
        {
            updateCond(cursorPos);
        }
        else if (cursorPos == SHOP_BUTTON_POS)
        {
            actMouseAnim(shopMask, shopTransform);
        }
        else if (shopActive) {
            updateShop(cursorPos);
        }
		else if (cursorPos == SHOP_FOOD)
		{
			actMouseAnim(foodMask, foodTransform);
		}
		else if (foodActive) {
			updateFood(cursorPos);
		}
		else if (cursorPos == SHOP_TOY)
		{
			actMouseAnim(toyMask, toyTransform);
		}
		else if (toyActive) {
			updateToy(cursorPos);
		}
		else if (cursorPos == SHOP_COM)
		{
			actMouseAnim(commMask, commTransform);
		}
		else if (commActive) {
			updateComm(cursorPos);
		}

		// >>>>> Sine >>>>>
		// Inventory Field
		else if (cursorPos == INVEN_BUTTON_POS)
		{
			actMouseAnim(inventoryMask, inventoryTransform);
		}
		else if (inventoryActive) {
			updateInven(cursorPos);
		}
		// <<<<< Sine <<<<<

        // FREE AREA
        else
        {
            clearTrans();
            clearActive();
            currMask = null;
            currTrans = null;
            ResetCounter();
        }
    }

    void updateCond( int cursorPos ) {
        // HUNGER
        if (cursorPos == CONDITION_HUNGER)
        {
            if (currMask != null)
            {
                currMask.gameObject.SetActive(false);
                if (currTrans != null && currTrans != conditionTransform)
                {
                    currTrans.gameObject.SetActive(false);
                }
                hungerMask.gameObject.SetActive(true);
                currMask = hungerMask;
                hungerTransform.gameObject.SetActive(true);
                currTrans = hungerTransform;
            }
        }
        // HAPPY
        else if (cursorPos == CONDITION_HAPPY)
        {
            if (currMask != null)
            {
                currMask.gameObject.SetActive(false);
                if (currTrans != null && currTrans != conditionTransform)
                {
                    currTrans.gameObject.SetActive(false);
                }
                happyMask.gameObject.SetActive(true);
                currMask = happyMask;
                happyTransform.gameObject.SetActive(true);
                currTrans = happyTransform;
            }
        }
        // CLEAN
        else if (cursorPos == CONDITION_CLEAN)
        {
            if (currTrans != null && currMask != null)
            {
                currMask.gameObject.SetActive(false);
                if (currTrans != conditionTransform)
                {
                    currTrans.gameObject.SetActive(false);
                }
                cleanMask.gameObject.SetActive(true);
                currMask = cleanMask;
                cleanTransform.gameObject.SetActive(true);
                currTrans = cleanTransform;
            }
        }
        // HEALTH
        else if (cursorPos == CONDITION_HEALTH)
        {
            if (currMask != null)
            {
                currMask.gameObject.SetActive(false);
                if (currTrans != null && currTrans != conditionTransform)
                {
                    currTrans.gameObject.SetActive(false);
                }
                healthMask.gameObject.SetActive(true);
                currMask = healthMask;
                healthTransform.gameObject.SetActive(true);
                currTrans = healthTransform;
            }
        }
        // CONDITION MENU
        else if (cursorPos == CONDITION_TRANS_POS)
        {
            if (currMask != null)
            {
                if (currTrans != null && currTrans != conditionTransform)
                {
                    currTrans.gameObject.SetActive(false);
                    currTrans = conditionTransform;
                }
                currMask.gameObject.SetActive(false);
            }
        }
        else
        {
            clearTrans();
            clearActive();
            currMask = null;
            currTrans = null;
            ResetCounter();
        }
    }
		
	void updateShop(int cursorPos)
	{
		if (cursorPos == SHOP_FOOD)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				foodMask.gameObject.SetActive(true);
				if (currTrans == shopTransform) {
					ResetCounter ();
				}
				currMask = foodMask;
				currTrans = foodTransform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == SHOP_TOY)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				toyMask.gameObject.SetActive(true);
				if (currTrans == shopTransform) {
					ResetCounter ();
				}
				currMask = toyMask;
				currTrans = toyTransform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == SHOP_COM)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				commMask.gameObject.SetActive(true);
				if (currTrans == shopTransform) {
					ResetCounter ();
				}
				currMask = commMask;
				currTrans = commTransform;
				actMouseAnim (currMask, currTrans);
			}
		}
		// INVENTORY MENU
		else if (cursorPos == SHOP_TRANS_POS)
		{
			if (currMask != null)
			{
				if (currTrans != null && currTrans != shopTransform)
				{
					currTrans.gameObject.SetActive(false);
					currTrans = shopTransform;
				}
				currMask.gameObject.SetActive(false);
			}
		}
		else
		{
			clearTrans();
			clearActive();
			currMask = null;
			currTrans = null;
			ResetCounter();
		}
	}
		
//	int SHOP_TOY_BALL = 222;
//	int SHOP_COM_TOWEL = 223;
//	int SHOP_COM_MED = 233;

	void updateFood(int cursorPos)
	{
		Debug.Log ("Sine : " + cursorPos + currTrans.name);
		if (cursorPos == SHOP_FOOD_DONUT) {
			if (currMask != null) {
				currMask.gameObject.SetActive (false);
				shopDonutsMask.gameObject.SetActive (true);
				if (currMask != shopDonutsMask) {
					ResetCounter ();
				}
				currMask = shopDonutsMask;
				actMouseAnim (currMask, transform);
			}
		} else if (cursorPos == SHOP_FOOD_BURGER) {
			if (currMask != null) {
				currMask.gameObject.SetActive (false);
				shopBurgerMask.gameObject.SetActive (true);
				if (currMask != shopBurgerMask) {
					ResetCounter ();
				}
				currMask = shopBurgerMask;
				actMouseAnim (currMask, transform);
			}
		} else if (cursorPos == SHOP_FOOD_MILK) {
			if (currMask != null) {
				currMask.gameObject.SetActive (false);
				shopMilkMask.gameObject.SetActive (true);
				if (currMask != shopMilkMask) {
					ResetCounter ();
				}
				currMask = shopMilkMask;
				actMouseAnim (currMask, transform);
			}
		}
		// INVENTORY MENU
		else if (cursorPos == SHOP_FOOD) {
			if (currMask != null) {
				if (currTrans != null && currTrans != foodTransform) {
					currTrans.gameObject.SetActive (false);
					currTrans = foodTransform;
				}
				currMask.gameObject.SetActive (false);
			}
		} else {
			clearTrans ();
			clearActive ();
			currMask = null;
			currTrans = null;
			ResetCounter ();
		}
	}

	void updateToy(int cursorPos)
	{
		if (cursorPos == SHOP_TOY_BALL) {
			if (currMask != null) {
				currMask.gameObject.SetActive (false);
				shopBallMask.gameObject.SetActive (true);
				if (currMask != shopBallMask) {
					ResetCounter ();
				}
				currMask = shopBallMask;
				actMouseAnim (currMask, transform);
			}
		}
		// INVENTORY MENU
		else if (cursorPos == SHOP_TOY) {
			if (currMask != null) {
				if (currTrans != null && currTrans != toyTransform) {
					currTrans.gameObject.SetActive (false);
					currTrans = toyTransform;
				}
				currMask.gameObject.SetActive (false);
			}
		} else {
			clearTrans ();
			clearActive ();
			currMask = null;
			currTrans = null;
			ResetCounter ();
		}
	}

	void updateComm(int cursorPos)
	{
		if (cursorPos == SHOP_COM_TOWEL) {
			if (currMask != null) {
				currMask.gameObject.SetActive (false);
				shopTowelMask.gameObject.SetActive (true);
				if (currMask != shopTowelMask) {
					ResetCounter ();
				}
				currMask = shopTowelMask;
				actMouseAnim (currMask, transform);
			}
		} else if (cursorPos == SHOP_COM_MED) {
			if (currMask != null) {
				currMask.gameObject.SetActive (false);
				shopMediMask.gameObject.SetActive (true);
				if (currMask != shopMediMask) {
					ResetCounter ();
				}
				currMask = shopMediMask;
				actMouseAnim (currMask, transform);
			}
		}

		// INVENTORY MENU
		else if (cursorPos == SHOP_COM) {
			if (currMask != null) {
				if (currTrans != null && currTrans != commTransform) {
					currTrans.gameObject.SetActive (false);
					currTrans = commTransform;
				}
				currMask.gameObject.SetActive (false);
			}
		} else {
			clearTrans ();
			clearActive ();
			currMask = null;
			currTrans = null;
			ResetCounter ();
		}
	}

	// >>>>> Sine >>>>>
	void updateInven(int cursorPos) {
		// BURGER
		if (cursorPos == INVEN_BURGER)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				burgerMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = burgerMask;
				currTrans = burgerObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == INVEN_DONUTS)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				donutsMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = donutsMask;
				currTrans = donutsObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == INVEN_DONUTS)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				donutsMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = donutsMask;
				currTrans = donutsObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == INVEN_MILK)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				milkMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = milkMask;
				currTrans = milkObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == INVEN_BALL)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				ballMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = ballMask;
				currTrans = ballObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == INVEN_TOWEL)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				towelMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = towelMask;
				currTrans = towelObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		else if (cursorPos == INVEN_MEDI)
		{
			if (currMask != null)
			{
				currMask.gameObject.SetActive(false);
				mediMask.gameObject.SetActive(true);
				if (currTrans == inventoryTransform) {
					ResetCounter ();
				}
				currMask = mediMask;
				currTrans = mediObject.transform;
				actMouseAnim (currMask, currTrans);
			}
		}
		// INVENTORY MENU
		else if (cursorPos == INVEN_TRANS_POS)
		{
			if (currMask != null)
			{
				if (currTrans != null && currTrans != inventoryTransform)
				{
					currTrans.gameObject.SetActive(false);
					currTrans = inventoryTransform;
				}
				currMask.gameObject.SetActive(false);
			}
		}
		else
		{
			clearTrans();
			clearActive();
			currMask = null;
			currTrans = null;
			ResetCounter();
		}
	}
	// >>>>> Sine >>>>> 


    void clearTrans() {
        conditionMask.gameObject.SetActive(false);
        hungerMask.gameObject.SetActive(false);
        happyMask.gameObject.SetActive(false);
        cleanMask.gameObject.SetActive(false);
        healthMask.gameObject.SetActive(false);

        conditionTransform.gameObject.SetActive(false);
        hungerTransform.gameObject.SetActive(false);
        happyTransform.gameObject.SetActive(false);
        cleanTransform.gameObject.SetActive(false);
        healthTransform.gameObject.SetActive(false);

		shopMask.gameObject.SetActive(false);
		foodMask.gameObject.SetActive(false);
		toyMask.gameObject.SetActive(false);
		commMask.gameObject.SetActive(false);

		shopBurgerMask.gameObject.SetActive(false);
		shopDonutsMask.gameObject.SetActive(false);
		shopMilkMask.gameObject.SetActive(false);
		shopBallMask.gameObject.SetActive(false);
		shopTowelMask.gameObject.SetActive(false);
		shopMediMask.gameObject.SetActive(false);

		shopTransform.gameObject.SetActive(false);
		foodTransform.gameObject.SetActive(false);
		toyTransform.gameObject.SetActive(false);
		commTransform.gameObject.SetActive(false);

		// >>>>> Sine >>>>>
		inventoryTransform.gameObject.SetActive(false);
		inventoryMask.gameObject.SetActive (false);
		// <<<<< Sine <<<<<
    }

	void clearActive() {
        conditionActive = false;
        shopActive = false;
		foodActive = false;
		toyActive = false;
		commActive = false;

		// >>>>> Sine >>>>>
		inventoryActive = false;
		// <<<<< Sine <<<<<
    }

    void ResetCounter() {
        counter = 0;
        fillAmount = 0.0f;
    }

    int isCursorEnter() {
        Vector2 pos = cursor.transform.position;
        // Condition
        if (120 >= pos.x && 10 <= pos.x && kheight - 20 >= pos.y && kheight - 340 <= pos.y)
        {
            if (120 >= pos.x && 20 <= pos.x && kheight - 20 >= pos.y && kheight - 120 <= pos.y)
            {
                return CONDITION_BUTTON_POS;
            }
            if (kheight - 120 >= pos.y && kheight - 160 <= pos.y)
            {
                return CONDITION_HUNGER;
            }
            if (kheight - 160 >= pos.y && kheight - 200 <= pos.y)
            {
                return CONDITION_HAPPY;
            }
            if (kheight - 200 >= pos.y && kheight - 240 <= pos.y)
            {
                return CONDITION_CLEAN;
            }
            if (kheight - 240 >= pos.y && kheight - 280 <= pos.y)
            {
                return CONDITION_HEALTH;
            }
            return CONDITION_TRANS_POS;
        }
        
		else if (120 >= pos.x && 20 <= pos.x && 120 >= pos.y && 20 <= pos.y)
		{
			return SHOP_BUTTON_POS;
		}
		else if (kwidth - 100 >= pos.x && 100 <= pos.x && kheight - 100 >= pos.y && 100 <= pos.y)
		{
			if (shopActive)
			{
				if (pos.x >= 100 && pos.x <= 380 && pos.y >= 120 && pos.y <= kheight - 120)
				{
					return SHOP_FOOD;
				}
				else if (pos.x >= 420 && pos.x <= 600 && pos.y >= 120 && pos.y <= kheight - 120)
				{
					return SHOP_TOY;
				}
				else if (pos.x >= 640 && pos.x <= 920 && pos.y >= 120 && pos.y <= kheight - 120)
				{
					return SHOP_COM;
				}
			}
			else if (foodActive)
			{
				if (pos.x >= 110 && pos.x <= 230 && pos.y >= kheight - 220 && pos.y <= kheight - 100)
				{
					return SHOP_FOOD_BURGER;
				}
				else if (pos.x >= (kwidth / 2) - 60 && pos.x <= (kwidth / 2) + 60 && pos.y >= kheight - 220 && pos.y <= kheight - 100)
				{
					return SHOP_FOOD_DONUT;
				}
				else if (pos.x >= kwidth - 230 && pos.x <= kwidth - 110 && pos.y >= kheight - 220 && pos.y <= kheight - 100)
				{
					return SHOP_FOOD_MILK;
				}
				return SHOP_FOOD;
			}
			else if (toyActive)
			{
				if (pos.x >= (kwidth / 2) - 60 && pos.x <= (kwidth / 2) + 60 && pos.y >= kheight - 220 && pos.y <= kheight - 100)
				{
					return SHOP_TOY_BALL;
				}
				return SHOP_TOY;
			}
			else if (commActive)
			{
				if (pos.x >= 110 && pos.x <= 230 && pos.y >= kheight - 220 && pos.y <= kheight - 100)
				{
					return SHOP_COM_TOWEL;
				}
				else if (pos.x >= kwidth - 230 && pos.x <= kwidth - 110 && pos.y >= kheight - 220 && pos.y <= kheight - 100)
				{
					return SHOP_COM_MED;
				}
				return SHOP_COM;
			}
			return SHOP_TRANS_POS;
		}

		// >>>>> Sine >>>>>
		else if (kwidth - 20 >= pos.x && kwidth - 220 <= pos.x && kheight >= pos.y && kheight - 450 <= pos.y) {
//			Debug.Log("Sine : " + cursor.transform.position + "  " + kwidth + "  " + kheight);
			if (kwidth - 20 >= pos.x && kwidth - 120 <= pos.x && kheight - 20 >= pos.y && kheight - 140 <= pos.y)
			{
				return INVEN_BUTTON_POS;
			}
			if (kwidth - 120 >= pos.x && kwidth - 220 <= pos.x && kheight - 140 >= pos.y && kheight - 190 <= pos.y)
			{
				return INVEN_BURGER;
			}
			if (kwidth - 20 >= pos.x && kwidth - 120 <= pos.x && kheight - 140 >= pos.y && kheight - 190 <= pos.y)
			{
				return INVEN_DONUTS;
			}
			if (kwidth - 120 >= pos.x && kwidth - 220 <= pos.x && kheight - 190 >= pos.y && kheight - 240 <= pos.y)
			{
				return INVEN_MILK;
			}
			if (kwidth - 20 >= pos.x && kwidth - 120 <= pos.x && kheight - 190 >= pos.y && kheight - 240 <= pos.y)
			{
				return INVEN_BALL;
			}
			if (kwidth - 120 >= pos.x && kwidth - 220 <= pos.x && kheight - 240 >= pos.y && kheight - 290 <= pos.y)
			{
				return INVEN_TOWEL;
			}
			if (kwidth - 20 >= pos.x && kwidth - 120 <= pos.x && kheight - 240 >= pos.y && kheight - 290 <= pos.y)
			{
				return INVEN_MEDI;
			}
			return INVEN_TRANS_POS;
		}
		// <<<<< Sine <<<<<

        return -1;
    }

    void actMouseAnim(Image mask, Transform trans) {
        if (counter == 100)
        {
            trans.gameObject.SetActive(true);
            mask.gameObject.SetActive(false);
            currTrans = trans;
            counter = 0;
            if (mask == conditionMask) {
                conditionActive = true;
            }

			if (mask == shopMask) {
				shopActive = true;
			}
			if (mask == foodMask) {
				shopTransform.gameObject.SetActive (false);
				foodTransform.gameObject.SetActive(true);
				clearActive();
				foodActive = true;
			}
			if (mask == toyMask) {
				shopTransform.gameObject.SetActive (false);
				toyTransform.gameObject.SetActive(true);
				clearActive();
				toyActive = true;
			}
			if (mask == commMask) {
				shopTransform.gameObject.SetActive (false);
				commTransform.gameObject.SetActive(true);
				clearActive();
				commActive = true;
			}

			if (mask == shopBurgerMask) {
				foodTransform.gameObject.SetActive (false);
				clearActive();
				clearTrans ();
			}
			if (mask == shopDonutsMask) {
				foodTransform.gameObject.SetActive (false);
				clearActive();
				clearTrans ();
			}
			if (mask == shopMilkMask) {
				foodTransform.gameObject.SetActive (false);
				clearActive();
				clearTrans ();
			}
			if (mask == shopBallMask) {
				toyTransform.gameObject.SetActive (false);
				clearActive();
				clearTrans ();
			}
			if (mask == shopTowelMask) {
				commTransform.gameObject.SetActive (false);
				clearActive();
				clearTrans ();
			}
			if (mask == shopMediMask) {
				commTransform.gameObject.SetActive (false);
				clearActive();
				clearTrans ();
			}


			// >>>>> Sine >>>>>
			if (mask == inventoryMask) {
				inventoryActive = true;
			}
			if (mask == burgerMask) {
				burgerObject.SetActive(true);
				clearActive();
			}
			if (mask == donutsMask) {
				donutsObject.SetActive(true);
				clearActive ();
			}
			if (mask == milkMask) {
				milkObject.SetActive(true);
				clearActive ();
			}
			if (mask == ballMask) {
				ballObject.SetActive(true);
				clearActive ();
			}
			if (mask == towelMask) {
				towelObject.SetActive(true);
				clearActive ();
			}
			if (mask == mediMask) {
				mediObject.SetActive(true);
				clearActive ();
			}
			// <<<<< Sine <<<<<

        }
        else {
			currMask = mask;
            counter++;
            fillAmount += 0.01f;
            mask.gameObject.SetActive(true);
            mask.fillAmount = fillAmount;
        }
    }

    Vector2 kinectToReal(Vector2 pos) {
        float realX = ( pos.x + 33.5f ) * kwidth / 67;
        float realY = ( pos.y + 14.5f ) * kheight / 29;
        Vector2 realPos = new Vector2(realX, realY);
        return realPos;
    }
}
