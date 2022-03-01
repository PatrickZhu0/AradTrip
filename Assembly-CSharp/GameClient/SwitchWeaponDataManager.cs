using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020012FF RID: 4863
	public class SwitchWeaponDataManager : DataManager<SwitchWeaponDataManager>
	{
		// Token: 0x0600BCA2 RID: 48290 RVA: 0x002C13A0 File Offset: 0x002BF7A0
		public override void Initialize()
		{
			for (byte b = 0; b < 1; b += 1)
			{
				this.sideWeaponDic[b] = 0UL;
			}
		}

		// Token: 0x0600BCA3 RID: 48291 RVA: 0x002C13CE File Offset: 0x002BF7CE
		public override EEnterGameOrder GetOrder()
		{
			return base.GetOrder();
		}

		// Token: 0x0600BCA4 RID: 48292 RVA: 0x002C13D6 File Offset: 0x002BF7D6
		public override void Clear()
		{
			this.sideWeaponDic.Clear();
		}

		// Token: 0x0600BCA5 RID: 48293 RVA: 0x002C13E4 File Offset: 0x002BF7E4
		public void TakeOnSideWeapon(uint index, ulong id)
		{
			SceneSetWeaponBarReq sceneSetWeaponBarReq = new SceneSetWeaponBarReq();
			sceneSetWeaponBarReq.index = (byte)(index - 1U);
			sceneSetWeaponBarReq.weaponId = id;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneSetWeaponBarReq>(ServerType.GATE_SERVER, sceneSetWeaponBarReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<SceneSetWeaponBarRes>(delegate(SceneSetWeaponBarRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BCA6 RID: 48294 RVA: 0x002C1448 File Offset: 0x002BF848
		public void UpdateSideWeapon(List<ulong> list)
		{
			for (int i = 0; i < list.Count; i++)
			{
				this.sideWeaponDic[(byte)i] = list[i];
			}
		}

		// Token: 0x0600BCA7 RID: 48295 RVA: 0x002C1480 File Offset: 0x002BF880
		public bool IsInSidePack(ItemData data)
		{
			if (data.GUID == 0UL)
			{
				return false;
			}
			foreach (KeyValuePair<byte, ulong> keyValuePair in this.sideWeaponDic)
			{
				if (data.GUID == keyValuePair.Value)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BCA8 RID: 48296 RVA: 0x002C1500 File Offset: 0x002BF900
		public ulong GetPosWeapon(uint index)
		{
			ulong result = 0UL;
			this.sideWeaponDic.TryGetValue((byte)index, out result);
			return result;
		}

		// Token: 0x0600BCA9 RID: 48297 RVA: 0x002C1524 File Offset: 0x002BF924
		public bool MainAndSideBothHaveWeapon()
		{
			bool flag = false;
			foreach (KeyValuePair<byte, ulong> keyValuePair in this.sideWeaponDic)
			{
				if (keyValuePair.Value != 0UL)
				{
					flag = true;
					break;
				}
			}
			ulong mainWeapon = DataManager<ItemDataManager>.GetInstance().GetMainWeapon();
			return flag && mainWeapon > 0UL;
		}

		// Token: 0x0600BCAA RID: 48298 RVA: 0x002C15AC File Offset: 0x002BF9AC
		public Dictionary<byte, ulong> GetSideWeaponDic()
		{
			return this.sideWeaponDic;
		}

		// Token: 0x0600BCAB RID: 48299 RVA: 0x002C15B4 File Offset: 0x002BF9B4
		public List<ulong> GetSideWeaponIDList()
		{
			return this.sideWeaponDic.Values.ToList<ulong>();
		}

		// Token: 0x04006A24 RID: 27172
		private Dictionary<byte, ulong> sideWeaponDic = new Dictionary<byte, ulong>();
	}
}
