using System;
using System.Collections.Generic;
using GamePool;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B25 RID: 6949
	public class ComModelBinder : MonoBehaviour
	{
		// Token: 0x06011115 RID: 69909 RVA: 0x004E46C8 File Offset: 0x004E2AC8
		public ComModelBinder()
		{
			int[] array = new int[4];
			array[1] = 1;
			this.mPlayList = array;
			base..ctor();
		}

		// Token: 0x06011116 RID: 69910 RVA: 0x004E46E0 File Offset: 0x004E2AE0
		public void LoadAvatar(int occu)
		{
			this.mOccu = occu;
			this.mDirty = true;
		}

		// Token: 0x06011117 RID: 69911 RVA: 0x004E46F0 File Offset: 0x004E2AF0
		private void _LoadAvatar(int occu)
		{
			JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null && null != this.mAvatar)
				{
					this.mAvatar.LoadAvatar(tableItem2.ModelPath, -1);
					this.mAvatar.ChangeAction(ComModelBinder.ms_ActionTable[0], 1f, true);
				}
			}
		}

		// Token: 0x06011118 RID: 69912 RVA: 0x004E4775 File Offset: 0x004E2B75
		public void SetFashions(List<ItemData> datas)
		{
			this.mFashions = datas;
			this.mDirty = true;
		}

		// Token: 0x06011119 RID: 69913 RVA: 0x004E4788 File Offset: 0x004E2B88
		public void SetFashion(ItemData data)
		{
			if (this._IsFashion(data) && null != this.mAvatar)
			{
				EFashionWearSlotType efashionWearSlotType = EFashionWearSlotType.Invalid;
				GeAvatarChannel geAvatarChannel = GeAvatarChannel.MaxChannelNum;
				DataManager<PlayerBaseData>.GetInstance().GetFashionSlotChangedType(ref efashionWearSlotType, ref geAvatarChannel, data.TableData, true);
				if (efashionWearSlotType != EFashionWearSlotType.Invalid)
				{
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mAvatar, efashionWearSlotType, data.TableID, null, 0, false);
				}
			}
		}

		// Token: 0x0601111A RID: 69914 RVA: 0x004E47EC File Offset: 0x004E2BEC
		private void _SetFashions(List<ItemData> datas)
		{
			if (null != this.mAvatar)
			{
				List<int> list = ListPool<int>.Get();
				list.Add(4);
				list.Add(5);
				list.Add(2);
				if (datas != null)
				{
					for (int i = 0; i < datas.Count; i++)
					{
						if (this._IsFashion(datas[i]))
						{
							EFashionWearSlotType efashionWearSlotType = EFashionWearSlotType.Invalid;
							GeAvatarChannel geAvatarChannel = GeAvatarChannel.MaxChannelNum;
							DataManager<PlayerBaseData>.GetInstance().GetFashionSlotChangedType(ref efashionWearSlotType, ref geAvatarChannel, datas[i].TableData, true);
							if (efashionWearSlotType != EFashionWearSlotType.Invalid)
							{
								list.Remove((int)efashionWearSlotType);
								DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mAvatar, efashionWearSlotType, datas[i].TableID, null, 0, false);
							}
						}
					}
					bool flag = false;
					bool flag2 = false;
					for (int j = 0; j < datas.Count; j++)
					{
						if (this._IsFashion(datas[j]))
						{
							if (datas[j].SubType == 11)
							{
								DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.mAvatar, datas[j].TableID, null, false);
								flag = true;
							}
							else if (datas[j].SubType == 92)
							{
								DataManager<PlayerBaseData>.GetInstance().AvatarEquipHalo(this.mAvatar, datas[j].TableID, null, false, false);
								flag2 = true;
							}
						}
					}
					if (!flag)
					{
						DataManager<PlayerBaseData>.GetInstance().AvatarEquipWing(this.mAvatar, 0, null, false);
					}
					if (!flag2)
					{
						DataManager<PlayerBaseData>.GetInstance().AvatarEquipHalo(this.mAvatar, 0, null, false, false);
					}
				}
				for (int k = 0; k < list.Count; k++)
				{
					EFashionWearSlotType efashionWearSlotType2 = (EFashionWearSlotType)list[k];
					GeAvatarChannel geAvatarChannel2 = this._getChannelBySlot(efashionWearSlotType2);
					DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.mAvatar, efashionWearSlotType2, 0, null, 0, false);
				}
				if (null != this.mAvatar)
				{
					this.mAvatar.SuitAvatar(true, false);
				}
				ListPool<int>.Release(list);
			}
		}

		// Token: 0x0601111B RID: 69915 RVA: 0x004E49F4 File Offset: 0x004E2DF4
		private GeAvatarChannel _getChannelBySlot(EFashionWearSlotType slot)
		{
			GeAvatarChannel result = GeAvatarChannel.MaxChannelNum;
			if (slot != EFashionWearSlotType.Head)
			{
				if (slot != EFashionWearSlotType.UpperBody)
				{
					if (slot == EFashionWearSlotType.LowerBody)
					{
						result = GeAvatarChannel.LowerPart;
					}
				}
				else
				{
					result = GeAvatarChannel.UpperPart;
				}
			}
			else
			{
				result = GeAvatarChannel.Head;
			}
			return result;
		}

		// Token: 0x0601111C RID: 69916 RVA: 0x004E4A33 File Offset: 0x004E2E33
		private bool _IsFashion(ItemData data)
		{
			return data != null && data.SubType >= 11 && data.SubType <= 16;
		}

		// Token: 0x0601111D RID: 69917 RVA: 0x004E4A58 File Offset: 0x004E2E58
		public void LoadWeapon()
		{
			this.mDirty = true;
		}

		// Token: 0x0601111E RID: 69918 RVA: 0x004E4A61 File Offset: 0x004E2E61
		private void _LoadWeapon()
		{
			if (null != this.mAvatar)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipCurrentWeapon(this.mAvatar, null, false);
			}
		}

		// Token: 0x0601111F RID: 69919 RVA: 0x004E4A86 File Offset: 0x004E2E86
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemsAttrChanged, new ClientEventSystem.UIEventHandler(this._OnItemAttrChanged));
		}

		// Token: 0x06011120 RID: 69920 RVA: 0x004E4AA3 File Offset: 0x004E2EA3
		private void Start()
		{
			this._Refresh();
			this.mDirty = false;
		}

		// Token: 0x06011121 RID: 69921 RVA: 0x004E4AB2 File Offset: 0x004E2EB2
		private void _Refresh()
		{
			this._LoadAvatar(this.mOccu);
			this._LoadWeapon();
			this._SetFashions(this.mFashions);
		}

		// Token: 0x06011122 RID: 69922 RVA: 0x004E4AD4 File Offset: 0x004E2ED4
		private void Update()
		{
			if (this.mDirty)
			{
				this._Refresh();
				this.mDirty = false;
				return;
			}
			if (null != this.mAvatar)
			{
				while (Global.Settings.avatarLightDir.x > 360f)
				{
					GlobalSetting settings = Global.Settings;
					settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
				}
				while (Global.Settings.avatarLightDir.x < 0f)
				{
					GlobalSetting settings2 = Global.Settings;
					settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
				}
				while (Global.Settings.avatarLightDir.y > 360f)
				{
					GlobalSetting settings3 = Global.Settings;
					settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
				}
				while (Global.Settings.avatarLightDir.y < 0f)
				{
					GlobalSetting settings4 = Global.Settings;
					settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
				}
				while (Global.Settings.avatarLightDir.z > 360f)
				{
					GlobalSetting settings5 = Global.Settings;
					settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
				}
				while (Global.Settings.avatarLightDir.z < 0f)
				{
					GlobalSetting settings6 = Global.Settings;
					settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
				}
				this.mAvatar.m_LightRot = Global.Settings.avatarLightDir;
				if (this.mAvatar.IsCurActionEnd())
				{
					this.mAvatar.ChangeAction(ComModelBinder.ms_ActionTable[this.mPlayList[this.mPlayIdx]], 1f, false);
					this.mPlayIdx++;
					if (this.mPlayIdx >= this.mPlayList.Length)
					{
						this.mPlayIdx = Random.Range(0, this.mPlayList.Length);
					}
					this.mPlayIdx %= this.mPlayList.Length;
				}
			}
		}

		// Token: 0x06011123 RID: 69923 RVA: 0x004E4CF4 File Offset: 0x004E30F4
		private void _OnItemAttrChanged(UIEvent uiEvent)
		{
			this.LoadWeapon();
		}

		// Token: 0x06011124 RID: 69924 RVA: 0x004E4CFC File Offset: 0x004E30FC
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemsAttrChanged, new ClientEventSystem.UIEventHandler(this._OnItemAttrChanged));
		}

		// Token: 0x0400AFDC RID: 45020
		public RawImage mRawImage;

		// Token: 0x0400AFDD RID: 45021
		public GeAvatarRendererEx mAvatar;

		// Token: 0x0400AFDE RID: 45022
		protected readonly int[] mPlayList;

		// Token: 0x0400AFDF RID: 45023
		protected int mPlayIdx;

		// Token: 0x0400AFE0 RID: 45024
		private static readonly string[] ms_ActionTable = new string[]
		{
			"Anim_Show_Idle",
			"Anim_Show_Idle_special01"
		};

		// Token: 0x0400AFE1 RID: 45025
		private bool mDirty;

		// Token: 0x0400AFE2 RID: 45026
		private int mOccu;

		// Token: 0x0400AFE3 RID: 45027
		private List<ItemData> mFashions;
	}
}
