using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000F96 RID: 3990
public class TreasureMapBuff : MonoBehaviour
{
	// Token: 0x06009A48 RID: 39496 RVA: 0x001DC85C File Offset: 0x001DAC5C
	private void InitTRValue()
	{
		string arg = TR.Value("treasure_map_dungeon_key_name");
		string arg2 = TR.Value("treasure_map_dungeon_map_name");
		string arg3 = TR.Value("treasure_map_dungeon_defend_name");
		string arg4 = TR.Value("treasure_map_dungeon_debuff_name");
		string arg5 = string.Format(TreasureMapBuff.mNameStringFormat, arg);
		string arg6 = string.Format(TreasureMapBuff.mNameStringFormat, arg2);
		string arg7 = string.Format(TreasureMapBuff.mNameStringFormat, arg3);
		string arg8 = string.Format(TreasureMapBuff.mNameStringFormat, arg4);
		string text = TR.Value("treasure_map_dungeon_key_detail");
		string text2 = TR.Value("treasure_map_dungeon_map_detail");
		string text3 = TR.Value("treasure_map_dungeon_defend_detail");
		string text4 = TR.Value("treasure_map_dungeon_debuff_detail");
		this.mActiveMapString = string.Format("{0}{1}\n{2}", arg, TreasureMapBuff.mUnActiveString, text);
		this.mActiveKeyString = string.Format("{0}{1}\n{2}", arg2, TreasureMapBuff.mUnActiveString, text2);
		this.mActiveDefendString = string.Format("{0}{1}\n{2}", arg3, TreasureMapBuff.mUnActiveString, text3);
		this.mActiveDebuffString = string.Format("{0}{1}\n{2}", arg4, TreasureMapBuff.mUnActiveString, text4);
		this.mActiveColorMapString = string.Format("{0}{1}\n{2}", arg5, TreasureMapBuff.mUnActiveString, text);
		this.mActiveColorKeyString = string.Format("{0}{1}\n{2}", arg6, TreasureMapBuff.mUnActiveString, text2);
		this.mActiveColorDefendString = string.Format("{0}{1}\n{2}", arg7, TreasureMapBuff.mUnActiveString, text3);
		this.mActiveColorDebuffString = string.Format("{0}{1}\n{2}", arg8, TreasureMapBuff.mUnActiveString, text4);
		this.mMapString = string.Format("{0}\n{1}", arg, text);
		this.mKeyString = string.Format("{0}\n{1}", arg2, text2);
		this.mDefendString = string.Format("{0}\n{1}", arg3, text3);
		this.mDebuffString = string.Format("{0}\n{1}", arg4, text4);
		this.mColorMapString = string.Format("{0}\n{1}", arg5, text);
		this.mColorKeyString = string.Format("{0}\n{1}", arg6, text2);
		this.mColorDefendString = string.Format("{0}\n{1}", arg7, text3);
		this.mColorDebuffString = string.Format("{0}\n{1}", arg8, text4);
	}

	// Token: 0x06009A49 RID: 39497 RVA: 0x001DCA5C File Offset: 0x001DAE5C
	private void Start()
	{
		this.InitTRValue();
		this.mToggleArray = new Toggle[]
		{
			this.mKeyToggle,
			this.mMapToggle,
			this.mHuiZhangToggle,
			this.mHufuToggle
		};
		this.mImageArray = new Image[]
		{
			this.mKeyImage,
			this.mMapImage,
			this.mHuiZhangImage,
			this.mHufuImage
		};
		if (this.mTextRoot)
		{
			this.mTextRoot.SetActive(false);
		}
		this.InitBuffList();
		if (this.mTextBtn)
		{
			this.mTextBtn.onClick.AddListener(delegate()
			{
				for (int i = 0; i < this.mToggleArray.Length; i++)
				{
					this.mToggleArray[i].isOn = false;
				}
				this.mTextRoot.SetActive(false);
			});
		}
	}

	// Token: 0x06009A4A RID: 39498 RVA: 0x001DCB20 File Offset: 0x001DAF20
	private void InitBuffList()
	{
		this.mKeyToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnKeyToggleClick));
		this.mMapToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnMapToggleClick));
		this.mHuiZhangToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnHuiZhangToggleClick));
		this.mHufuToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnHufuToggleClick));
	}

	// Token: 0x06009A4B RID: 39499 RVA: 0x001DCBA0 File Offset: 0x001DAFA0
	private void OnKeyToggleClick(bool flag)
	{
		if (flag)
		{
			this.mTextRoot.transform.position = this.mKeyToggle.transform.position;
			this.mTextRoot.SetActive(true);
			if (this.mKeyImage.enabled)
			{
				this.mFakeText.text = this.mActiveKeyString;
				this.mRealText.text = this.mActiveColorKeyString;
			}
			else
			{
				this.mFakeText.text = this.mKeyString;
				this.mRealText.text = this.mColorKeyString;
			}
		}
		else
		{
			this.mTextRoot.SetActive(false);
		}
	}

	// Token: 0x06009A4C RID: 39500 RVA: 0x001DCC4C File Offset: 0x001DB04C
	private void OnMapToggleClick(bool flag)
	{
		if (flag)
		{
			this.mTextRoot.transform.position = this.mMapToggle.transform.position;
			this.mTextRoot.SetActive(true);
			if (this.mMapImage.enabled)
			{
				this.mFakeText.text = this.mActiveMapString;
				this.mRealText.text = this.mActiveColorMapString;
			}
			else
			{
				this.mFakeText.text = this.mMapString;
				this.mRealText.text = this.mColorMapString;
			}
		}
		else
		{
			this.mTextRoot.SetActive(false);
		}
	}

	// Token: 0x06009A4D RID: 39501 RVA: 0x001DCCF8 File Offset: 0x001DB0F8
	private void OnHuiZhangToggleClick(bool flag)
	{
		if (flag)
		{
			this.mTextRoot.transform.position = this.mHuiZhangToggle.transform.position;
			this.mTextRoot.SetActive(true);
			if (this.mHuiZhangImage.enabled)
			{
				this.mFakeText.text = this.mActiveDefendString;
				this.mRealText.text = this.mActiveColorDefendString;
			}
			else
			{
				this.mFakeText.text = this.mDefendString;
				this.mRealText.text = this.mColorDefendString;
			}
		}
		else
		{
			this.mTextRoot.SetActive(false);
		}
	}

	// Token: 0x06009A4E RID: 39502 RVA: 0x001DCDA4 File Offset: 0x001DB1A4
	private void OnHufuToggleClick(bool flag)
	{
		if (flag)
		{
			this.mTextRoot.transform.position = this.mHufuToggle.transform.position;
			this.mTextRoot.SetActive(true);
			if (this.mHufuImage.enabled)
			{
				this.mFakeText.text = this.mActiveDebuffString;
				this.mRealText.text = this.mActiveColorDebuffString;
			}
			else
			{
				this.mFakeText.text = this.mDebuffString;
				this.mRealText.text = this.mColorDebuffString;
			}
		}
		else
		{
			this.mTextRoot.SetActive(false);
		}
	}

	// Token: 0x06009A4F RID: 39503 RVA: 0x001DCE50 File Offset: 0x001DB250
	public void HideLock(int buffId)
	{
		if (buffId == 570205)
		{
			this.mKeyImage.enabled = false;
		}
		if (buffId == 570206)
		{
			this.mMapImage.enabled = false;
		}
		if (buffId == 570172)
		{
			this.mHufuImage.enabled = false;
		}
		if (buffId == 570173)
		{
			this.mHuiZhangImage.enabled = false;
		}
	}

	// Token: 0x04004FB9 RID: 20409
	public Toggle mKeyToggle;

	// Token: 0x04004FBA RID: 20410
	public Image mKeyImage;

	// Token: 0x04004FBB RID: 20411
	public Toggle mMapToggle;

	// Token: 0x04004FBC RID: 20412
	public Image mMapImage;

	// Token: 0x04004FBD RID: 20413
	public Toggle mHuiZhangToggle;

	// Token: 0x04004FBE RID: 20414
	public Image mHuiZhangImage;

	// Token: 0x04004FBF RID: 20415
	public Toggle mHufuToggle;

	// Token: 0x04004FC0 RID: 20416
	public Image mHufuImage;

	// Token: 0x04004FC1 RID: 20417
	public GameObject mTextRoot;

	// Token: 0x04004FC2 RID: 20418
	public Button mTextBtn;

	// Token: 0x04004FC3 RID: 20419
	public Text mFakeText;

	// Token: 0x04004FC4 RID: 20420
	public Text mRealText;

	// Token: 0x04004FC5 RID: 20421
	private Toggle[] mToggleArray;

	// Token: 0x04004FC6 RID: 20422
	private Image[] mImageArray;

	// Token: 0x04004FC7 RID: 20423
	private string mMapString;

	// Token: 0x04004FC8 RID: 20424
	private string mKeyString;

	// Token: 0x04004FC9 RID: 20425
	private string mDefendString;

	// Token: 0x04004FCA RID: 20426
	private string mDebuffString;

	// Token: 0x04004FCB RID: 20427
	private string mColorMapString;

	// Token: 0x04004FCC RID: 20428
	private string mColorKeyString;

	// Token: 0x04004FCD RID: 20429
	private string mColorDefendString;

	// Token: 0x04004FCE RID: 20430
	private string mColorDebuffString;

	// Token: 0x04004FCF RID: 20431
	private string mActiveMapString;

	// Token: 0x04004FD0 RID: 20432
	private string mActiveKeyString;

	// Token: 0x04004FD1 RID: 20433
	private string mActiveDefendString;

	// Token: 0x04004FD2 RID: 20434
	private string mActiveDebuffString;

	// Token: 0x04004FD3 RID: 20435
	private string mActiveColorMapString;

	// Token: 0x04004FD4 RID: 20436
	private string mActiveColorKeyString;

	// Token: 0x04004FD5 RID: 20437
	private string mActiveColorDefendString;

	// Token: 0x04004FD6 RID: 20438
	private string mActiveColorDebuffString;

	// Token: 0x04004FD7 RID: 20439
	private static string mNameStringFormat = "<color=#FFCA00>{0}</color>";

	// Token: 0x04004FD8 RID: 20440
	private static string mUnActiveString = "   <color=#BD3C31>（未激活）</color>";
}
