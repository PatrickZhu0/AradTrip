using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B0 RID: 5040
	internal class PlAcquireConfirmFrame : ClientFrame
	{
		// Token: 0x0600C397 RID: 50071 RVA: 0x002ED768 File Offset: 0x002EBB68
		private int _GetQueryValue(string key)
		{
			int result = 0;
			ActiveManager.ActivityData childActiveData = DataManager<ActiveManager>.GetInstance().GetChildActiveData(8101);
			if (childActiveData != null)
			{
				TaskPair taskPair = childActiveData.akActivityValues.Find((TaskPair x) => x.key == key);
				if (taskPair == null || int.TryParse(taskPair.value, out result))
				{
				}
			}
			return result;
		}

		// Token: 0x0600C398 RID: 50072 RVA: 0x002ED7CC File Offset: 0x002EBBCC
		private int _GetExpPerValue()
		{
			int result = 0;
			int id = this._GetQueryValue(this.keyLv);
			FatigueMakeUp tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FatigueMakeUp>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (!this.data.bPerfect)
				{
					result = tableItem.LowEXP;
				}
				else
				{
					result = tableItem.HiEXP;
				}
			}
			return result;
		}

		// Token: 0x0600C399 RID: 50073 RVA: 0x002ED828 File Offset: 0x002EBC28
		private int _GetTotalMoneyCost(int curPl)
		{
			string key = (!this.data.bPerfect) ? this.key_lgf : this.key_hgf;
			int num = this._GetQueryValue(key);
			int num2 = 0;
			int num3 = this._FindZone(num);
			int num4 = this._FindZone(num + curPl);
			if (num3 != -1 && num4 != -1)
			{
				int num5 = num;
				while (num3 != num4)
				{
					FatigueMakeUpPrice fatigueMakeUpPrice = this.mPriceItems[num3];
					int num6 = (!this.data.bPerfect) ? fatigueMakeUpPrice.LowPrice : fatigueMakeUpPrice.HiPrice;
					num2 += (fatigueMakeUpPrice.FatigueSection[1] - num5) * num6;
					num5 = fatigueMakeUpPrice.FatigueSection[1];
					num3++;
				}
				FatigueMakeUpPrice fatigueMakeUpPrice2 = this.mPriceItems[num3];
				int num7 = (!this.data.bPerfect) ? fatigueMakeUpPrice2.LowPrice : fatigueMakeUpPrice2.HiPrice;
				num2 += (num + curPl - num5) * num7;
			}
			else
			{
				Logger.LogErrorFormat("iPrePl = {0} iPrePl + curPl = {1}", new object[]
				{
					num,
					num + curPl
				});
			}
			return num2;
		}

		// Token: 0x0600C39A RID: 50074 RVA: 0x002ED958 File Offset: 0x002EBD58
		private int _FindZone(int pl)
		{
			int result = -1;
			for (int i = 0; i < this.mPriceItems.Count; i++)
			{
				FatigueMakeUpPrice fatigueMakeUpPrice = this.mPriceItems[i];
				if (pl >= fatigueMakeUpPrice.FatigueSection[0] && pl <= fatigueMakeUpPrice.FatigueSection[1])
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600C39B RID: 50075 RVA: 0x002ED9BC File Offset: 0x002EBDBC
		private int _ConvertToItems(int iQueryValue)
		{
			if (iQueryValue % this.valuePerCount == 0)
			{
				iQueryValue /= this.valuePerCount;
			}
			else
			{
				iQueryValue = iQueryValue / this.valuePerCount + 1;
			}
			return iQueryValue;
		}

		// Token: 0x0600C39C RID: 50076 RVA: 0x002ED9E8 File Offset: 0x002EBDE8
		private int _GetMaxCount()
		{
			int num = this._GetQueryValue(this.keyLeftFagure);
			num = this._ConvertToItems(num);
			return IntMath.Max(1, num);
		}

		// Token: 0x0600C39D RID: 50077 RVA: 0x002EDA14 File Offset: 0x002EBE14
		private void _OnIValueChanged(int curValue)
		{
			this.curValue = curValue;
			int num = this._GetMaxCount();
			int num2 = this._GetQueryValue(this.keyLeftFagure);
			int num3 = IntMath.Min(num2, curValue * this.valuePerCount);
			this.curPl.text = string.Format("{0} 点", num3);
			this.count.text = curValue.ToString();
			this.getExp.text = (num3 * this._GetExpPerValue()).ToString();
			this.btnMin.enabled = (curValue > 1);
			this.grayMin.enabled = !this.btnMin.enabled;
			this.btnMinus.enabled = (curValue > 1);
			this.grayMinus.enabled = !this.btnMinus.enabled;
			this.btnAdd.enabled = (curValue < num);
			this.grayAdd.enabled = !this.btnAdd.enabled;
			this.btnMax.enabled = (curValue < num);
			this.grayMax.enabled = !this.btnMax.enabled;
			int num4 = IntMath.Min(curValue * this.valuePerCount, num2);
			this.inputField.text = num4.ToString();
			this.moneyCount.text = this._GetTotalMoneyCost(num3).ToString();
			if (num <= 1)
			{
				this.slider.value = 1f;
			}
			else
			{
				this.slider.value = (float)(curValue - 1) * 1f / (float)(num - 1);
			}
		}

		// Token: 0x0600C39E RID: 50078 RVA: 0x002EDBBE File Offset: 0x002EBFBE
		[UIEventHandle("Middle/min")]
		private void _OnClickMin()
		{
			if (this.curValue != 1)
			{
				this.curValue = 1;
				this._OnIValueChanged(this.curValue);
			}
		}

		// Token: 0x0600C39F RID: 50079 RVA: 0x002EDBDF File Offset: 0x002EBFDF
		[UIEventHandle("Middle/minus")]
		private void _OnClickMinus()
		{
			if (this.curValue > 1)
			{
				this.curValue--;
				this._OnIValueChanged(this.curValue);
			}
		}

		// Token: 0x0600C3A0 RID: 50080 RVA: 0x002EDC08 File Offset: 0x002EC008
		[UIEventHandle("Middle/add")]
		private void _OnClickAdd()
		{
			int num = this._GetMaxCount();
			if (this.curValue < num)
			{
				this.curValue++;
				this._OnIValueChanged(this.curValue);
			}
		}

		// Token: 0x0600C3A1 RID: 50081 RVA: 0x002EDC44 File Offset: 0x002EC044
		[UIEventHandle("Middle/max")]
		private void _OnClickMax()
		{
			int num = this._GetMaxCount();
			if (this.curValue != num)
			{
				this.curValue = num;
				this._OnIValueChanged(this.curValue);
			}
		}

		// Token: 0x0600C3A2 RID: 50082 RVA: 0x002EDC78 File Offset: 0x002EC078
		private void _OnInputFieldChanged(string value)
		{
			int num = 1;
			int.TryParse(value, out num);
			int num2 = num;
			num2 = IntMath.Max(num2, 1);
			num2 = IntMath.Min(num2, this._GetMaxCount());
			if (num2 != num)
			{
				this.inputField.text = num2.ToString();
				num = num2;
			}
			if (num != this.curValue)
			{
				this.curValue = num;
				this._OnIValueChanged(num);
			}
		}

		// Token: 0x0600C3A3 RID: 50083 RVA: 0x002EDCE4 File Offset: 0x002EC0E4
		private void _OnValueChanged(float fValue)
		{
			int num = this._GetMaxCount();
			int num2 = (int)(fValue * (float)(num - 1) + 0.5f) + 1;
			if (num2 < 1)
			{
				num2 = 1;
			}
			if (num2 != this.curValue)
			{
				this.curValue = num2;
				this._OnIValueChanged(num2);
			}
		}

		// Token: 0x0600C3A4 RID: 50084 RVA: 0x002EDD2C File Offset: 0x002EC12C
		[UIEventHandle("CostItem/costbg")]
		private void _OnClickGetExp()
		{
			if (this.data == null || this.data.activityData == null)
			{
				if (this.data == null)
				{
					Logger.LogErrorFormat("data is null _OnClickGetExp !!", new object[0]);
				}
				else if (this.data.activityData == null)
				{
					Logger.LogErrorFormat("activityData is null _OnClickGetExp!!", new object[0]);
				}
				return;
			}
			int num = this._GetQueryValue(this.keyLeftFagure);
			if (this.curValue > this._ConvertToItems(num))
			{
				Logger.LogErrorFormat("placquire getvalue largger than queryvalue ,curvalue = {0} ,maxvalue = {1}", new object[]
				{
					this.curValue,
					this._ConvertToItems(num)
				});
				return;
			}
			int num2 = IntMath.Min(num, this.curValue * this.valuePerCount);
			int nCount = this._GetTotalMoneyCost(num2);
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
			{
				nMoneyID = this.data.itemId,
				nCount = nCount
			}, delegate
			{
				int num3 = this.data.iValue;
				num3 &= -65536;
				num3 |= (this.curValue & 65535);
				DataManager<ActiveManager>.GetInstance().SendSubmitActivity(this.data.activityData.ID, (uint)num3);
				this.frameMgr.CloseFrame<PlAcquireConfirmFrame>(this, false);
			}, "common_money_cost", null);
		}

		// Token: 0x0600C3A5 RID: 50085 RVA: 0x002EDE39 File Offset: 0x002EC239
		[UIEventHandle("closeicon")]
		private void _OnClickClose()
		{
			this.frameMgr.CloseFrame<PlAcquireConfirmFrame>(this, false);
		}

		// Token: 0x0600C3A6 RID: 50086 RVA: 0x002EDE48 File Offset: 0x002EC248
		public static void Open(PlAcquireConfirmFrameData data)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlAcquireConfirmFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x0600C3A7 RID: 50087 RVA: 0x002EDE5C File Offset: 0x002EC25C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/PlAcquireAwardFrame";
		}

		// Token: 0x0600C3A8 RID: 50088 RVA: 0x002EDE64 File Offset: 0x002EC264
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as PlAcquireConfirmFrameData);
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(214, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.valuePerCount = tableItem.Value;
			}
			ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.data.itemId, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.titleName.text = string.Format("{0}找回", tableItem2.Name);
				ETCImageLoader.LoadSprite(ref this.moneyIcon, tableItem2.Icon, true);
			}
			if (this.mPriceItems == null)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FatigueMakeUpPrice>();
				if (table != null)
				{
					this.mPriceItems = new List<FatigueMakeUpPrice>(table.Count);
					Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
					while (enumerator.MoveNext())
					{
						List<FatigueMakeUpPrice> list = this.mPriceItems;
						KeyValuePair<int, object> keyValuePair = enumerator.Current;
						list.Add(keyValuePair.Value as FatigueMakeUpPrice);
					}
				}
			}
			this.slider.onValueChanged.AddListener(new UnityAction<float>(this._OnValueChanged));
			this._OnIValueChanged(1);
		}

		// Token: 0x0600C3A9 RID: 50089 RVA: 0x002EDF8A File Offset: 0x002EC38A
		protected override void _OnCloseFrame()
		{
			this.slider.onValueChanged.RemoveListener(new UnityAction<float>(this._OnValueChanged));
			this.data = null;
		}

		// Token: 0x04006F11 RID: 28433
		private PlAcquireConfirmFrameData data;

		// Token: 0x04006F12 RID: 28434
		[UIControl("Name", typeof(Text), 0)]
		private Text titleName;

		// Token: 0x04006F13 RID: 28435
		[UIControl("TodayPl", typeof(Text), 0)]
		private Text totalPl;

		// Token: 0x04006F14 RID: 28436
		[UIControl("CurPl", typeof(Text), 0)]
		private Text curPl;

		// Token: 0x04006F15 RID: 28437
		[UIControl("Exp", typeof(Text), 0)]
		private Text getExp;

		// Token: 0x04006F16 RID: 28438
		[UIControl("Middle/count/Text", typeof(Text), 0)]
		private Text count;

		// Token: 0x04006F17 RID: 28439
		[UIControl("Middle/min", typeof(UIGray), 0)]
		private UIGray grayMin;

		// Token: 0x04006F18 RID: 28440
		[UIControl("Middle/minus", typeof(UIGray), 0)]
		private UIGray grayMinus;

		// Token: 0x04006F19 RID: 28441
		[UIControl("Middle/add", typeof(UIGray), 0)]
		private UIGray grayAdd;

		// Token: 0x04006F1A RID: 28442
		[UIControl("Middle/max", typeof(UIGray), 0)]
		private UIGray grayMax;

		// Token: 0x04006F1B RID: 28443
		[UIControl("Middle/min", typeof(Button), 0)]
		private Button btnMin;

		// Token: 0x04006F1C RID: 28444
		[UIControl("Middle/minus", typeof(Button), 0)]
		private Button btnMinus;

		// Token: 0x04006F1D RID: 28445
		[UIControl("Middle/add", typeof(Button), 0)]
		private Button btnAdd;

		// Token: 0x04006F1E RID: 28446
		[UIControl("Middle/max", typeof(Button), 0)]
		private Button btnMax;

		// Token: 0x04006F1F RID: 28447
		[UIControl("Middle/slider", typeof(Slider), 0)]
		private Slider slider;

		// Token: 0x04006F20 RID: 28448
		[UIControl("Middle/count", typeof(InputField), 0)]
		private InputField inputField;

		// Token: 0x04006F21 RID: 28449
		[UIControl("CostItem/costbg/Horizen/icon", typeof(Image), 0)]
		private Image moneyIcon;

		// Token: 0x04006F22 RID: 28450
		[UIControl("CostItem/costbg/Horizen/costnum", typeof(Text), 0)]
		private Text moneyCount;

		// Token: 0x04006F23 RID: 28451
		private const int min = 1;

		// Token: 0x04006F24 RID: 28452
		private int valuePerCount = 25;

		// Token: 0x04006F25 RID: 28453
		private string keyLeftFagure = "lf";

		// Token: 0x04006F26 RID: 28454
		private string keyLv = "lv";

		// Token: 0x04006F27 RID: 28455
		private List<FatigueMakeUpPrice> mPriceItems;

		// Token: 0x04006F28 RID: 28456
		private string key_lgf = "lgf";

		// Token: 0x04006F29 RID: 28457
		private string key_hgf = "hgf";

		// Token: 0x04006F2A RID: 28458
		private int curValue = 1;
	}
}
