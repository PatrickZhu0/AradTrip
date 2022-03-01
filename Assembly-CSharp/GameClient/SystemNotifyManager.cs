using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200117E RID: 4478
	public class SystemNotifyManager
	{
		// Token: 0x0600AB37 RID: 43831 RVA: 0x0024B5F8 File Offset: 0x002499F8
		public static SystemNotifyManager GetInstance()
		{
			return SystemNotifyManager.hInstance;
		}

		// Token: 0x0600AB38 RID: 43832 RVA: 0x0024B600 File Offset: 0x00249A00
		public static void Clear()
		{
			SystemNotifyManager.CommonAnimInterval = 0f;
			SystemNotifyManager.CommonAnimList.Clear();
			SystemNotifyManager.CommonAnimInterval2 = 0f;
			SystemNotifyManager.CommonAnimList2.Clear();
			SystemNotifyManager.CommonAnimListcontent2.Clear();
			SystemNotifyManager.FloatingEffectInterval = 0f;
			SystemNotifyManager.FloatingEffectPosInterval = 0f;
			SystemNotifyManager.FloatingEffectListPos.Clear();
			SystemNotifyManager.dungeonSkillTip = null;
			for (int i = 0; i < SystemNotifyManager.FloatingImmediateEffectList.Count; i++)
			{
			}
			SystemNotifyManager.FloatingImmediateEffectList.Clear();
			for (int j = 0; j < SystemNotifyManager.FloatingImmediateEffectList2.Count; j++)
			{
			}
			SystemNotifyManager.FloatingImmediateEffectList2.Clear();
			SystemNotifyManager.AwardNotifyCount = 0;
			SystemNotifyManager.FloatingEffectList.Clear();
		}

		// Token: 0x0600AB39 RID: 43833 RVA: 0x0024B6C0 File Offset: 0x00249AC0
		public static void SysNotifyFromServer(SysNotify res)
		{
			if (res.type == 100 || res.word == string.Empty || res.word == "-" || res.word.Length <= 0)
			{
				return;
			}
			if (res.type == 21)
			{
				SystemNotifyManager.SwitchNotifyType(res.word, CommonTipsDesc.eShowType.CT_TEXT_FLOAT_EFFECT, null, null, null, CommonTipsDesc.eShowMode.SI_QUEUE, 0, 0f, FrameLayer.High, false, null);
			}
			else
			{
				SystemNotifyManager.SwitchNotifyType(res.word, (CommonTipsDesc.eShowType)res.type, null, null, null, CommonTipsDesc.eShowMode.SI_IMMEDIATELY, 0, 0f, FrameLayer.High, false, null);
			}
		}

		// Token: 0x0600AB3A RID: 43834 RVA: 0x0024B760 File Offset: 0x00249B60
		public static void SystemNotify(int NotifyID, string DescEx = "")
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, null, null, DescEx);
		}

		// Token: 0x0600AB3B RID: 43835 RVA: 0x0024B76C File Offset: 0x00249B6C
		public static void SystemNotifyOkCancel(int NotifyID, UnityAction OnOKCallBack, UnityAction OnCancelCallBack, FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(NotifyID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SetCommonMsgBoxOK(string.Format("[通用提示表]没有添加错误码[{0}]对应的提示内容", NotifyID), null, null, string.Empty, FrameLayer.High, false);
				return;
			}
			SystemNotifyManager.SwitchNotifyType(tableItem.Descs, tableItem.ShowType, tableItem, OnOKCallBack, OnCancelCallBack, tableItem.ShowMode, 0, 0f, layer, bExclusive, null);
		}

		// Token: 0x0600AB3C RID: 43836 RVA: 0x0024B7D8 File Offset: 0x00249BD8
		public static void SystemNotify(int NotifyID, UnityAction OnOKCallBack, UnityAction OnCancelCallBack)
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, OnOKCallBack, OnCancelCallBack, string.Empty);
		}

		// Token: 0x0600AB3D RID: 43837 RVA: 0x0024B7E7 File Offset: 0x00249BE7
		public static void SystemNotify(int NotifyID, UnityAction OnOKCallBack)
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, OnOKCallBack, null, string.Empty);
		}

		// Token: 0x0600AB3E RID: 43838 RVA: 0x0024B7F6 File Offset: 0x00249BF6
		public static void SystemNotify(int NotifyID, params object[] args)
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, null, null, 0, args);
		}

		// Token: 0x0600AB3F RID: 43839 RVA: 0x0024B802 File Offset: 0x00249C02
		public static void SystemNotify(int NotifyID, UnityAction OnOKCallBack, UnityAction OnCancelCallBack, params object[] args)
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, OnOKCallBack, OnCancelCallBack, 0, args);
		}

		// Token: 0x0600AB40 RID: 43840 RVA: 0x0024B80E File Offset: 0x00249C0E
		public static void SystemNotify(int NotifyID, UnityAction OnOKCallBack, UnityAction OnCancelCallBack, float fWaitTime, params object[] args)
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, OnOKCallBack, OnCancelCallBack, fWaitTime, args);
		}

		// Token: 0x0600AB41 RID: 43841 RVA: 0x0024B81B File Offset: 0x00249C1B
		public static void SystemNotify(int NotifyID, int itemTableId, params object[] args)
		{
			SystemNotifyManager.ComSysNotifyByTableID(NotifyID, null, null, itemTableId, args);
		}

		// Token: 0x0600AB42 RID: 43842 RVA: 0x0024B828 File Offset: 0x00249C28
		public static void SysNotifyMsgBoxOK(string msgContent, UnityAction OnOKCallBack = null, string OkBtnText = "", bool bExclusive = false)
		{
			string content = SystemNotifyManager.SwitchNotifyDescription(msgContent, null);
			SystemNotifyManager.SetCommonMsgBoxOK(content, null, OnOKCallBack, OkBtnText, FrameLayer.High, bExclusive);
		}

		// Token: 0x0600AB43 RID: 43843 RVA: 0x0024B848 File Offset: 0x00249C48
		public static void SysNotifyMsgBoxOkCancel(string msgContent, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, float fCountDownTime = 0f, bool bExclusive = false)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_MSG_BOX_OK_CANCEL, null, OnOKCallBack, OnCancelCallBack, CommonTipsDesc.eShowMode.SI_NULL, 0, fCountDownTime, FrameLayer.High, bExclusive, null);
		}

		// Token: 0x0600AB44 RID: 43844 RVA: 0x0024B868 File Offset: 0x00249C68
		public static void SysNotifyMsgBoxOkCancel(string msgContent, string OkBtnText, string CancelBtnText, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, FrameLayer layer = FrameLayer.High)
		{
			string content = SystemNotifyManager.SwitchNotifyDescription(msgContent, null);
			SystemNotifyManager.SetCommonMsgBoxOKCancel(content, null, OnOKCallBack, OnCancelCallBack, OkBtnText, CancelBtnText, 0f, layer, false);
		}

		// Token: 0x0600AB45 RID: 43845 RVA: 0x0024B894 File Offset: 0x00249C94
		public static void SysNotifyMsgBoxCancelOk(string msgContent, UnityAction OnCancelCallBack = null, UnityAction OnOKCallBack = null, float fCountDownTime = 0f, bool bExclusive = false, CommonMsgBoxCancelOKParams param = null)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_MSG_BOX_CANCEL_OK, null, OnOKCallBack, OnCancelCallBack, CommonTipsDesc.eShowMode.SI_NULL, 0, fCountDownTime, FrameLayer.High, bExclusive, new object[]
			{
				param
			});
		}

		// Token: 0x0600AB46 RID: 43846 RVA: 0x0024B8BC File Offset: 0x00249CBC
		public static void SysNotifyMsgBoxCancelOk(string msgContent, string CancelBtnText, string OkBtnText, UnityAction OnCancelCallBack = null, UnityAction OnOKCallBack = null, float fCountDownTime = 0f, bool bExclusive = false, CommonMsgBoxCancelOKParams param = null)
		{
			string content = SystemNotifyManager.SwitchNotifyDescription(msgContent, null);
			SystemNotifyManager.SetCommonMsgBoxCancelOK(content, null, OnCancelCallBack, OnOKCallBack, CancelBtnText, OkBtnText, fCountDownTime, FrameLayer.High, bExclusive, param, false);
		}

		// Token: 0x0600AB47 RID: 43847 RVA: 0x0024B8E8 File Offset: 0x00249CE8
		public static void SysNotifyMsgBoxCancelOk(string msgContent, string CancelBtnText, string OkBtnText, UnityAction OnCancelCallBack = null, UnityAction OnOKCallBack = null, float fCountDownTime = 0f, bool bExclusive = false, CommonMsgBoxCancelOKParams param = null, bool bIsCountDownTimeOKBtn = false)
		{
			SystemNotifyManager.SetCommonMsgBoxCancelOK(msgContent, null, OnCancelCallBack, OnOKCallBack, CancelBtnText, OkBtnText, fCountDownTime, FrameLayer.High, bExclusive, param, bIsCountDownTimeOKBtn);
		}

		// Token: 0x0600AB48 RID: 43848 RVA: 0x0024B90C File Offset: 0x00249D0C
		public static void SysNotifyConfirmFrame(string msgContent, UnityAction OnOKCallBack = null)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_CLICK_CONFIRM_FRAME, null, OnOKCallBack, null, CommonTipsDesc.eShowMode.SI_NULL, 0, 0f, FrameLayer.High, false, null);
		}

		// Token: 0x0600AB49 RID: 43849 RVA: 0x0024B930 File Offset: 0x00249D30
		public static void SysNotifyTextAnimation(string msgContent, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_UNIQUE)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_SYSTEM_TEXT_ANIMATION, null, null, null, eShowMode, 0, 0f, FrameLayer.High, false, null);
		}

		// Token: 0x0600AB4A RID: 43850 RVA: 0x0024B954 File Offset: 0x00249D54
		public static void SysNotifyFloatingEffect(string msgContent, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_QUEUE, int itemId = 0)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_TEXT_FLOAT_EFFECT, null, null, null, eShowMode, itemId, 0f, FrameLayer.High, false, null);
		}

		// Token: 0x0600AB4B RID: 43851 RVA: 0x0024B976 File Offset: 0x00249D76
		public static void BaseMsgBoxOK(string msgContent, UnityAction OnOKCallBack = null, string OKtext = "")
		{
			SystemNotifyManager.SetBaseMsgBoxOK(msgContent, OKtext, null, OnOKCallBack, FrameLayer.High);
		}

		// Token: 0x0600AB4C RID: 43852 RVA: 0x0024B984 File Offset: 0x00249D84
		public static void HotUpdateMsgBoxOkCancel(string msgContent, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_HOT_UPDATE_OK_CANCEL, null, OnOKCallBack, OnCancelCallBack, CommonTipsDesc.eShowMode.SI_NULL, 0, 0f, FrameLayer.High, false, null);
		}

		// Token: 0x0600AB4D RID: 43853 RVA: 0x0024B9A6 File Offset: 0x00249DA6
		public static void BaseMsgBoxOkCancel(string msgContent, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, string OkBtnText = "", string CancelBtnText = "")
		{
			SystemNotifyManager.SetBaseMsgBoxOKCancel(msgContent, null, OnOKCallBack, OnCancelCallBack, OkBtnText, CancelBtnText, FrameLayer.High);
		}

		// Token: 0x0600AB4E RID: 43854 RVA: 0x0024B9B8 File Offset: 0x00249DB8
		public static void HotUpdateMsgBoxOk(string msgContent, UnityAction OnOKCallBack = null)
		{
			SystemNotifyManager.SwitchNotifyType(msgContent, CommonTipsDesc.eShowType.CT_HOT_UPDATE_OK, null, OnOKCallBack, null, CommonTipsDesc.eShowMode.SI_NULL, 0, 0f, FrameLayer.High, false, null);
		}

		// Token: 0x0600AB4F RID: 43855 RVA: 0x0024B9DA File Offset: 0x00249DDA
		public static void SysNotifyFloatingEffectByPos(string msgContent, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_QUEUE)
		{
			SystemNotifyManager.SetFloatingEffectShowMode(msgContent, eShowMode, 0, true, FrameLayer.High);
		}

		// Token: 0x0600AB50 RID: 43856 RVA: 0x0024B9E8 File Offset: 0x00249DE8
		public static CommonItemAwardFrame CreateSysNotifyCommonItemAwardFrame()
		{
			string name = string.Format("ItemAwardNotify{0}", SystemNotifyManager.AwardNotifyCount);
			CommonItemAwardFrame result = Singleton<ClientSystemManager>.instance.OpenFrame<CommonItemAwardFrame>(FrameLayer.High, null, name) as CommonItemAwardFrame;
			SystemNotifyManager.AwardNotifyCount++;
			return result;
		}

		// Token: 0x0600AB51 RID: 43857 RVA: 0x0024BA2A File Offset: 0x00249E2A
		public static void SysDungeonAnimation(string msgContent, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_UNIQUE)
		{
			SystemNotifyManager.SetDungeonAnimationShowMode(msgContent, eShowMode, FrameLayer.High);
		}

		// Token: 0x0600AB52 RID: 43858 RVA: 0x0024BA34 File Offset: 0x00249E34
		public static void SysDungeonAnimation2(string msgContent, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_UNIQUE)
		{
			SystemNotifyManager.SetDungeonAnimation2ShowMode(msgContent, eShowMode, FrameLayer.High);
		}

		// Token: 0x0600AB53 RID: 43859 RVA: 0x0024BA40 File Offset: 0x00249E40
		public static GameObject SysDungeonSkillTip(string msgContent, float duration = 5f, bool wait = false)
		{
			GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.HighLayer, "CommonTipSkill", false);
			if (gameObject == null)
			{
				gameObject = SystemNotifyManager.CreateSysDungeonTip();
			}
			ComTipSkill component = gameObject.GetComponent<ComTipSkill>();
			if (component != null)
			{
				component.InitBindUI();
				component.SetSkillTips(msgContent, duration, wait);
			}
			SystemNotifyManager.dungeonSkillTip = gameObject;
			return gameObject;
		}

		// Token: 0x0600AB54 RID: 43860 RVA: 0x0024BA9E File Offset: 0x00249E9E
		public static void ClearDungeonSkillTip()
		{
			if (SystemNotifyManager.dungeonSkillTip == null)
			{
				return;
			}
			Object.Destroy(SystemNotifyManager.dungeonSkillTip);
		}

		// Token: 0x0600AB55 RID: 43861 RVA: 0x0024BABB File Offset: 0x00249EBB
		public static void SysNotifyTextAnimation2(string msgContent, string msgContent2, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_UNIQUE)
		{
			SystemNotifyManager.SetNotifyTextAnimation2ShowMode(msgContent, msgContent2, eShowMode);
		}

		// Token: 0x0600AB56 RID: 43862 RVA: 0x0024BAC8 File Offset: 0x00249EC8
		private static void ComSysNotifyByTableID(int NotifyID, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, string DescEx = "")
		{
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(NotifyID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SetCommonMsgBoxOK(string.Format("[通用提示表]没有添加错误码[{0}]对应的提示内容", NotifyID), null, null, string.Empty, FrameLayer.High, false);
				return;
			}
			if (DescEx.Length > 0)
			{
				SystemNotifyManager.SwitchNotifyType(DescEx, tableItem.ShowType, tableItem, OnOKCallBack, OnCancelCallBack, tableItem.ShowMode, 0, 0f, FrameLayer.High, false, null);
			}
			else
			{
				SystemNotifyManager.SwitchNotifyType(tableItem.Descs, tableItem.ShowType, tableItem, OnOKCallBack, OnCancelCallBack, tableItem.ShowMode, 0, 0f, FrameLayer.High, false, null);
			}
		}

		// Token: 0x0600AB57 RID: 43863 RVA: 0x0024BB64 File Offset: 0x00249F64
		private static void ComSysNotifyByTableID(int NotifyID, UnityAction OnOKCallBack, UnityAction OnCancelCallBack, int iItemTableID, params object[] args)
		{
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(NotifyID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SetCommonMsgBoxOK(string.Format("[通用提示表]没有添加错误码[{0}]对应的提示内容", NotifyID), null, null, string.Empty, FrameLayer.High, false);
				return;
			}
			SystemNotifyManager.SwitchNotifyType(tableItem.Descs, tableItem.ShowType, tableItem, OnOKCallBack, OnCancelCallBack, tableItem.ShowMode, iItemTableID, 0f, FrameLayer.High, false, args);
		}

		// Token: 0x0600AB58 RID: 43864 RVA: 0x0024BBD0 File Offset: 0x00249FD0
		private static void ComSysNotifyByTableID(int NotifyID, UnityAction OnOKCallBack, UnityAction OnCancelCallBack, float fWaitTime, params object[] args)
		{
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(NotifyID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SetCommonMsgBoxOK(string.Format("[通用提示表]没有添加错误码[{0}]对应的提示内容", NotifyID), null, null, string.Empty, FrameLayer.High, false);
				return;
			}
			SystemNotifyManager.SwitchNotifyType(tableItem.Descs, tableItem.ShowType, tableItem, OnOKCallBack, OnCancelCallBack, tableItem.ShowMode, 0, fWaitTime, FrameLayer.High, false, args);
		}

		// Token: 0x0600AB59 RID: 43865 RVA: 0x0024BC38 File Offset: 0x0024A038
		public static void SysNotifyGetNewItemEffect(ItemData itemData, bool bHighValue = false, string msgContent = "")
		{
			GetItemEffectFrame getItemEffectFrame;
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GetItemEffectFrame>(null))
			{
				getItemEffectFrame = (Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(GetItemEffectFrame)) as GetItemEffectFrame);
			}
			else
			{
				getItemEffectFrame = (Singleton<ClientSystemManager>.GetInstance().OpenFrame<GetItemEffectFrame>(FrameLayer.Middle, null, string.Empty) as GetItemEffectFrame);
			}
			if (getItemEffectFrame != null)
			{
				getItemEffectFrame.AddNewItem(itemData, bHighValue);
			}
			else
			{
				Logger.LogError("can not open or get GetItemEffectFrame");
			}
		}

		// Token: 0x0600AB5A RID: 43866 RVA: 0x0024BCAC File Offset: 0x0024A0AC
		private static void SwitchNotifyType(string Content, CommonTipsDesc.eShowType eShowtype, CommonTipsDesc NotifyData = null, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, CommonTipsDesc.eShowMode eShowMode = CommonTipsDesc.eShowMode.SI_UNIQUE, int itemId = 0, float fCountDownTime = 0f, FrameLayer layer = FrameLayer.High, bool bExclusive = false, params object[] args)
		{
			string content = SystemNotifyManager.SwitchNotifyDescription(Content, args);
			if (eShowtype == CommonTipsDesc.eShowType.CT_MSG_BOX_OK)
			{
				SystemNotifyManager.SetCommonMsgBoxOK(content, NotifyData, OnOKCallBack, string.Empty, layer, bExclusive);
			}
			else if (eShowtype == CommonTipsDesc.eShowType.CT_MSG_BOX_OK_CANCEL)
			{
				SystemNotifyManager.SetCommonMsgBoxOKCancel(content, NotifyData, OnOKCallBack, OnCancelCallBack, string.Empty, string.Empty, fCountDownTime, layer, bExclusive);
			}
			else if (eShowtype == CommonTipsDesc.eShowType.CT_MSG_BOX_CANCEL_OK)
			{
				CommonMsgBoxCancelOKParams param = new CommonMsgBoxCancelOKParams();
				if (args != null && args.Length > 0)
				{
					param = (CommonMsgBoxCancelOKParams)args[0];
				}
				SystemNotifyManager.SetCommonMsgBoxCancelOK(content, NotifyData, OnCancelCallBack, OnOKCallBack, string.Empty, string.Empty, fCountDownTime, layer, bExclusive, param, false);
			}
			else if (eShowtype != CommonTipsDesc.eShowType.CT_CLICK_CONFIRM_FRAME)
			{
				if (eShowtype == CommonTipsDesc.eShowType.CT_SYSTEM_TEXT_ANIMATION)
				{
					SystemNotifyManager.SetCommonTextAnimationShowMode(content, eShowMode, layer);
				}
				else if (eShowtype == CommonTipsDesc.eShowType.CT_TEXT_FLOAT_EFFECT)
				{
					SystemNotifyManager.SetFloatingEffectShowMode(content, CommonTipsDesc.eShowMode.SI_QUEUE, itemId, false, layer);
				}
				else if (eShowtype == CommonTipsDesc.eShowType.CT_DUNGEON_TEXT_ANIMATION)
				{
					SystemNotifyManager.SetDungeonAnimationShowMode(content, eShowMode, layer);
				}
				else if (eShowtype == CommonTipsDesc.eShowType.CT_DUNGEON_TEXT_ANIMATION_2)
				{
					SystemNotifyManager.SetDungeonAnimation2ShowMode(content, eShowMode, layer);
				}
				else if (eShowtype == CommonTipsDesc.eShowType.CT_HOT_UPDATE_OK)
				{
					SystemNotifyManager.SetBaseMsgBoxOK(content, "确定", NotifyData, OnOKCallBack, layer);
				}
				else if (eShowtype == CommonTipsDesc.eShowType.CT_HOT_UPDATE_OK_CANCEL)
				{
					SystemNotifyManager.SetBaseMsgBoxOKCancel(content, NotifyData, OnOKCallBack, OnCancelCallBack, string.Empty, string.Empty, layer);
				}
			}
		}

		// Token: 0x0600AB5B RID: 43867 RVA: 0x0024BDF4 File Offset: 0x0024A1F4
		private static string SwitchNotifyDescription(string des, params object[] args)
		{
			string text = des;
			if (args != null)
			{
				string format = Regex.Replace(text, "\\{[\\w]*\\:([\\d]*)\\}", "{$1}");
				text = string.Format(format, args);
			}
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace("\\n", "\n");
			}
			return text;
		}

		// Token: 0x0600AB5C RID: 43868 RVA: 0x0024BE40 File Offset: 0x0024A240
		private static void SetCommonMsgBoxOK(string content, CommonTipsDesc NotifyData = null, UnityAction OnOKCallBack = null, string OkBtnText = "", FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			if (content == string.Empty || content == "-" || content.Length <= 0)
			{
				return;
			}
			CommonMsgBoxOK commonMsgBoxOK = SystemNotifyManager.CreateSysNotifyMsgBoxOK(layer, bExclusive);
			if (NotifyData != null)
			{
				commonMsgBoxOK.SetNotifyDataByTable(NotifyData, content);
			}
			else
			{
				commonMsgBoxOK.SetMsgContent(content);
				if (OkBtnText != string.Empty)
				{
					commonMsgBoxOK.SetOkBtnText(OkBtnText);
				}
			}
			if (OnOKCallBack != null)
			{
				commonMsgBoxOK.AddListener(OnOKCallBack);
			}
		}

		// Token: 0x0600AB5D RID: 43869 RVA: 0x0024BEC4 File Offset: 0x0024A2C4
		private static void SetCommonMsgBoxOKCancel(string content, CommonTipsDesc NotifyData = null, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, string OkBtnText = "", string CancelBtnText = "", float fCountDownTime = 0f, FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			if (content == string.Empty || content == "-" || content.Length <= 0)
			{
				return;
			}
			CommonMsgBoxOKCancel commonMsgBoxOKCancel = SystemNotifyManager.CreateSysNotifyMsgBoxOKCancel(layer, bExclusive);
			commonMsgBoxOKCancel.SetMsgContent(content);
			if (NotifyData != null)
			{
				commonMsgBoxOKCancel.SetNotifyDataByTable(NotifyData);
			}
			else
			{
				if (OkBtnText != string.Empty)
				{
					commonMsgBoxOKCancel.SetOkBtnText(OkBtnText);
				}
				if (CancelBtnText != string.Empty)
				{
					commonMsgBoxOKCancel.SetCancelBtnText(CancelBtnText);
				}
			}
			if (OnOKCallBack != null || OnCancelCallBack != null)
			{
				commonMsgBoxOKCancel.AddListener(OnOKCallBack, OnCancelCallBack);
			}
			if (fCountDownTime > 0f)
			{
				commonMsgBoxOKCancel.SetCountDownTime(fCountDownTime);
			}
		}

		// Token: 0x0600AB5E RID: 43870 RVA: 0x0024BF7C File Offset: 0x0024A37C
		public static void SetMallBuyMsgBoxOKCancel(string content, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			if (content == string.Empty || content == "-" || content.Length <= 0)
			{
				return;
			}
			CommonMsgBoxOKCancel commonMsgBoxOKCancel = SystemNotifyManager.CreateSysNotifyMsgBoxOKCancel(layer, bExclusive);
			commonMsgBoxOKCancel.SetMsgContent(content);
			commonMsgBoxOKCancel.SetbNotify(true);
			if (OnOKCallBack != null || OnCancelCallBack != null)
			{
				commonMsgBoxOKCancel.AddListener(OnOKCallBack, OnCancelCallBack);
			}
		}

		// Token: 0x0600AB5F RID: 43871 RVA: 0x0024BFE4 File Offset: 0x0024A3E4
		private static void SetCommonMsgBoxCancelOK(string content, CommonTipsDesc NotifyData = null, UnityAction OnCancelCallBack = null, UnityAction OnOKCallBack = null, string CancelBtnText = "", string OkBtnText = "", float fCountDownTime = 0f, FrameLayer layer = FrameLayer.High, bool bExclusive = false, CommonMsgBoxCancelOKParams param = null, bool bIsCountDownTimeOKBtn = false)
		{
			if (content == string.Empty || content == "-" || content.Length <= 0)
			{
				return;
			}
			CommonMsgBoxCancelOK commonMsgBoxCancelOK = SystemNotifyManager.CreateSysNotifyMsgBoxCancelOK(layer, bExclusive);
			commonMsgBoxCancelOK.SetMsgContent(content);
			commonMsgBoxCancelOK.InitMsgBox(param);
			if (NotifyData != null)
			{
				commonMsgBoxCancelOK.SetNotifyDataByTable(NotifyData);
			}
			else
			{
				if (CancelBtnText != string.Empty)
				{
					commonMsgBoxCancelOK.SetCancelBtnText(CancelBtnText);
				}
				if (OkBtnText != string.Empty)
				{
					commonMsgBoxCancelOK.SetOkBtnText(OkBtnText);
				}
			}
			if (OnOKCallBack != null || OnCancelCallBack != null)
			{
				commonMsgBoxCancelOK.AddListener(OnOKCallBack, OnCancelCallBack);
			}
			if (fCountDownTime > 0f)
			{
				commonMsgBoxCancelOK.SetCountDownTime(fCountDownTime, bIsCountDownTimeOKBtn);
			}
		}

		// Token: 0x0600AB60 RID: 43872 RVA: 0x0024C0A8 File Offset: 0x0024A4A8
		private static void SetBaseMsgBoxOK(string content, string OKtext = "", CommonTipsDesc NotifyData = null, UnityAction OnOKCallBack = null, FrameLayer layer = FrameLayer.High)
		{
			if (content == string.Empty || content == "-" || content.Length <= 0)
			{
				return;
			}
			BaseMsgBoxOK baseMsgBoxOK = SystemNotifyManager.CreateBaseMsgBoxOK();
			if (NotifyData != null)
			{
				baseMsgBoxOK.SetNotifyDataByTable(NotifyData, content);
			}
			else
			{
				baseMsgBoxOK.SetMsgContent(content);
			}
			if (OKtext != string.Empty)
			{
				baseMsgBoxOK.SetOKBtnText(OKtext);
			}
			if (OnOKCallBack != null)
			{
				baseMsgBoxOK.AddListener(OnOKCallBack);
			}
		}

		// Token: 0x0600AB61 RID: 43873 RVA: 0x0024C128 File Offset: 0x0024A528
		private static void SetBaseMsgBoxOKCancel(string content, CommonTipsDesc NotifyData = null, UnityAction OnOKCallBack = null, UnityAction OnCancelCallBack = null, string OkBtnText = "", string CancelBtnText = "", FrameLayer layer = FrameLayer.High)
		{
			if (content == string.Empty || content == "-" || content.Length <= 0)
			{
				return;
			}
			BaseMsgBoxOKCancel baseMsgBoxOKCancel = SystemNotifyManager.CreateBaseMsgBoxOKCancel();
			if (NotifyData != null)
			{
				baseMsgBoxOKCancel.SetNotifyDataByTable(NotifyData, content);
			}
			else
			{
				baseMsgBoxOKCancel.SetMsgContent(content);
				if (OkBtnText != string.Empty)
				{
					baseMsgBoxOKCancel.SetOkBtnText(OkBtnText);
				}
				if (CancelBtnText != string.Empty)
				{
					baseMsgBoxOKCancel.SetCancelBtnText(CancelBtnText);
				}
			}
			if (OnOKCallBack != null || OnCancelCallBack != null)
			{
				baseMsgBoxOKCancel.AddListener(OnOKCallBack, OnCancelCallBack);
			}
		}

		// Token: 0x0600AB62 RID: 43874 RVA: 0x0024C1C8 File Offset: 0x0024A5C8
		private static void SetCommonConfirmFrame(string content, CommonTipsDesc NotifyData = null, UnityAction OnOKCallBack = null, FrameLayer layer = FrameLayer.High)
		{
			CommonConfirmFrame commonConfirmFrame = SystemNotifyManager.CreateSysNotifyConfirmFrame();
			if (NotifyData != null)
			{
				commonConfirmFrame.SetNotifyDataByTable(NotifyData, content);
			}
			else
			{
				commonConfirmFrame.SetMsgContent(content);
			}
			if (OnOKCallBack != null)
			{
				commonConfirmFrame.AddListener(OnOKCallBack);
			}
		}

		// Token: 0x0600AB63 RID: 43875 RVA: 0x0024C202 File Offset: 0x0024A602
		private static void SetCommonTextAnimationShowMode(string content, CommonTipsDesc.eShowMode eShowMode, FrameLayer layer = FrameLayer.High)
		{
			SystemNotifyManager.SetFloatingEffectShowMode(content, eShowMode, 0, false, FrameLayer.High);
		}

		// Token: 0x0600AB64 RID: 43876 RVA: 0x0024C210 File Offset: 0x0024A610
		private static void SetFloatingEffectShowMode(string content, CommonTipsDesc.eShowMode eShowMode, int itemId = 0, bool bByPos = false, FrameLayer layer = FrameLayer.High)
		{
			if (!bByPos)
			{
				if (eShowMode == CommonTipsDesc.eShowMode.SI_UNIQUE)
				{
					GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.HighLayer, "FloatingEffect", false);
					if (gameObject != null)
					{
						return;
					}
				}
				else if (eShowMode == CommonTipsDesc.eShowMode.SI_QUEUE)
				{
					FloatEffectData item = default(FloatEffectData);
					item.text = content;
					item.itemId = itemId;
					SystemNotifyManager.FloatingEffectList.Add(item);
					return;
				}
				GameObject gameObject2 = SystemNotifyManager.CreateSysNotifyFloatingEffect();
				ComCalTime component = gameObject2.GetComponent<ComCalTime>();
				if (component != null)
				{
					component.BeginCalTime(true);
				}
				GameObject gameObject3 = gameObject2.transform.Find("pos").gameObject;
				GameObject gameObject4 = gameObject2.transform.Find("text").gameObject;
				GameObject gameObject5 = gameObject2.transform.Find("text2").gameObject;
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
				if (itemId <= 0 || tableItem == null)
				{
					gameObject3.SetActive(false);
					gameObject4.SetActive(false);
					gameObject5.GetComponent<Text>().text = content;
					SystemNotifyManager.FloatingImmediateEffectList.Add(gameObject2);
					return;
				}
				Image[] componentsInChildren = gameObject2.GetComponentsInChildren<Image>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					if (componentsInChildren[i].name == "icon")
					{
						ETCImageLoader.LoadSprite(ref componentsInChildren[i], tableItem.Icon, true);
						Image component2 = gameObject3.GetComponent<Image>();
						SystemNotifyManager.GetItemIconBackByQuality(ref component2, tableItem);
					}
				}
				gameObject4.GetComponent<Text>().text = content;
				gameObject5.SetActive(false);
				SystemNotifyManager.FloatingImmediateEffectList.Add(gameObject2);
			}
		}

		// Token: 0x0600AB65 RID: 43877 RVA: 0x0024C3B8 File Offset: 0x0024A7B8
		private static void SetDungeonAnimationShowMode(string content, CommonTipsDesc.eShowMode eShowMode, FrameLayer layer = FrameLayer.High)
		{
			if (eShowMode == CommonTipsDesc.eShowMode.SI_UNIQUE || eShowMode == CommonTipsDesc.eShowMode.SI_QUEUE)
			{
				GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.HighLayer, "CommonSysDungeonAnimation", false);
				if (gameObject != null)
				{
					return;
				}
			}
			GameObject gameObject2 = SystemNotifyManager.CreateSysDungeonAnimation();
			if (gameObject2 != null)
			{
				GameObject gameObject3 = gameObject2.transform.Find("Text").gameObject;
				if (gameObject3 != null)
				{
					Text component = gameObject3.GetComponent<Text>();
					if (component != null)
					{
						component.text = content;
					}
				}
			}
		}

		// Token: 0x0600AB66 RID: 43878 RVA: 0x0024C444 File Offset: 0x0024A844
		private static void SetDungeonAnimation2ShowMode(string content, CommonTipsDesc.eShowMode eShowMode, FrameLayer layer = FrameLayer.High)
		{
			if (eShowMode == CommonTipsDesc.eShowMode.SI_UNIQUE || eShowMode == CommonTipsDesc.eShowMode.SI_QUEUE)
			{
				GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.HighLayer, "CommonSysDungeonAnimation2", false);
				if (gameObject != null)
				{
					return;
				}
			}
			GameObject gameObject2 = SystemNotifyManager.CreateSysDungeonAnimation2();
			GameObject gameObject3 = gameObject2.transform.Find("Text").gameObject;
			gameObject3.GetComponent<Text>().text = content;
		}

		// Token: 0x0600AB67 RID: 43879 RVA: 0x0024C4AC File Offset: 0x0024A8AC
		private static void SetNotifyTextAnimation2ShowMode(string content, string content2, CommonTipsDesc.eShowMode eShowMode)
		{
			if (eShowMode == CommonTipsDesc.eShowMode.SI_UNIQUE)
			{
				GameObject gameObject = Utility.FindGameObject(Singleton<ClientSystemManager>.instance.HighLayer, "CommonTipAnimation2", false);
				if (gameObject != null)
				{
					return;
				}
			}
			else if (eShowMode == CommonTipsDesc.eShowMode.SI_QUEUE)
			{
				SystemNotifyManager.CommonAnimList2.Add(content);
				SystemNotifyManager.CommonAnimListcontent2.Add(content2);
				return;
			}
			GameObject gameObject2 = SystemNotifyManager.CreateSysCommonTextAnimation2();
			GameObject gameObject3 = gameObject2.transform.Find("Text").gameObject;
			gameObject3.GetComponent<Text>().text = content;
			GameObject gameObject4 = gameObject2.transform.Find("Text2").gameObject;
			gameObject4.GetComponent<Text>().text = content2;
		}

		// Token: 0x0600AB68 RID: 43880 RVA: 0x0024C550 File Offset: 0x0024A950
		private static CommonMsgBoxOK CreateSysNotifyMsgBoxOK(FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonMsgBoxOK>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOK>(null, false);
			}
			CommonMsgOutData commonMsgOutData = new CommonMsgOutData();
			commonMsgOutData.bExclusiveWithNewbieGuide = bExclusive;
			return Singleton<ClientSystemManager>.instance.OpenFrame<CommonMsgBoxOK>(layer, commonMsgOutData, string.Empty) as CommonMsgBoxOK;
		}

		// Token: 0x0600AB69 RID: 43881 RVA: 0x0024C5A0 File Offset: 0x0024A9A0
		private static CommonMsgBoxOKCancel CreateSysNotifyMsgBoxOKCancel(FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonMsgBoxOKCancel>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOKCancel>(null, false);
			}
			CommonMsgOutData commonMsgOutData = new CommonMsgOutData();
			commonMsgOutData.bExclusiveWithNewbieGuide = bExclusive;
			return Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonMsgBoxOKCancel>(layer, commonMsgOutData, string.Empty) as CommonMsgBoxOKCancel;
		}

		// Token: 0x0600AB6A RID: 43882 RVA: 0x0024C5F0 File Offset: 0x0024A9F0
		private static CommonMsgBoxCancelOK CreateSysNotifyMsgBoxCancelOK(FrameLayer layer = FrameLayer.High, bool bExclusive = false)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonMsgBoxCancelOK>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxCancelOK>(null, false);
			}
			CommonMsgOutData commonMsgOutData = new CommonMsgOutData();
			commonMsgOutData.bExclusiveWithNewbieGuide = bExclusive;
			return Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonMsgBoxCancelOK>(layer, commonMsgOutData, string.Empty) as CommonMsgBoxCancelOK;
		}

		// Token: 0x0600AB6B RID: 43883 RVA: 0x0024C640 File Offset: 0x0024AA40
		private static BaseMsgBoxOK CreateBaseMsgBoxOK()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BaseMsgBoxOK>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<BaseMsgBoxOK>(null, false);
			}
			return Singleton<ClientSystemManager>.instance.OpenFrame<BaseMsgBoxOK>(FrameLayer.High, null, string.Empty) as BaseMsgBoxOK;
		}

		// Token: 0x0600AB6C RID: 43884 RVA: 0x0024C684 File Offset: 0x0024AA84
		private static BaseMsgBoxOKCancel CreateBaseMsgBoxOKCancel()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BaseMsgBoxOKCancel>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<BaseMsgBoxOKCancel>(null, false);
			}
			return Singleton<ClientSystemManager>.instance.OpenFrame<BaseMsgBoxOKCancel>(FrameLayer.High, null, string.Empty) as BaseMsgBoxOKCancel;
		}

		// Token: 0x0600AB6D RID: 43885 RVA: 0x0024C6C8 File Offset: 0x0024AAC8
		private static CommonConfirmFrame CreateSysNotifyConfirmFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonConfirmFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonConfirmFrame>(null, false);
			}
			return Singleton<ClientSystemManager>.instance.OpenFrame<CommonConfirmFrame>(FrameLayer.High, null, string.Empty) as CommonConfirmFrame;
		}

		// Token: 0x0600AB6E RID: 43886 RVA: 0x0024C70C File Offset: 0x0024AB0C
		private static GameObject CreateSysCommonTextAnimation()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/CommonSystemNotify/CommonTipAnimation", true, 0U);
			gameObject.name = "CommonTipAnimation";
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			return gameObject;
		}

		// Token: 0x0600AB6F RID: 43887 RVA: 0x0024C748 File Offset: 0x0024AB48
		private static GameObject CreateSysCommonTextAnimation2()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/CommonSystemNotify/CommonTipAnimation2", true, 0U);
			gameObject.name = "CommonTipAnimation2";
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			return gameObject;
		}

		// Token: 0x0600AB70 RID: 43888 RVA: 0x0024C784 File Offset: 0x0024AB84
		private static GameObject CreateSysNotifyFloatingEffect()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/CommonSystemNotify/CommonFloatingEffect", true, 0U);
			gameObject.name = "FloatingEffect";
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			return gameObject;
		}

		// Token: 0x0600AB71 RID: 43889 RVA: 0x0024C7C0 File Offset: 0x0024ABC0
		private static GameObject CreateSysDungeonAnimation()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/CommonSystemNotify/CommonTipAnimation_Dungeon", true, 0U);
			gameObject.name = "CommonTipAnimation_Dungeon";
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			return gameObject;
		}

		// Token: 0x0600AB72 RID: 43890 RVA: 0x0024C7FC File Offset: 0x0024ABFC
		private static GameObject CreateSysDungeonAnimation2()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/CommonSystemNotify/TipGWQCAnimation", true, 0U);
			gameObject.name = "CommonSysDungeonAnimation2";
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			return gameObject;
		}

		// Token: 0x0600AB73 RID: 43891 RVA: 0x0024C838 File Offset: 0x0024AC38
		private static GameObject CreateSysDungeonTip()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Battle/CommonTipSkill", true, 0U);
			gameObject.name = "CommonTipSkill";
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.HighLayer, false);
			return gameObject;
		}

		// Token: 0x0600AB74 RID: 43892 RVA: 0x0024C874 File Offset: 0x0024AC74
		public void OnUpdate(float timeElapsed)
		{
			SystemNotifyManager.CommonAnimInterval += timeElapsed;
			SystemNotifyManager.CommonAnimInterval2 += timeElapsed;
			SystemNotifyManager.FloatingEffectInterval += timeElapsed;
			SystemNotifyManager.FloatingEffectPosInterval += timeElapsed;
			if (SystemNotifyManager.FloatingEffectInterval > 0.8f)
			{
				SystemNotifyManager.FloatingEffectInterval = 0f;
				if (SystemNotifyManager.FloatingEffectList.Count > 0)
				{
					SystemNotifyManager.SetFloatingEffectShowMode(SystemNotifyManager.FloatingEffectList[0].text, CommonTipsDesc.eShowMode.SI_IMMEDIATELY, SystemNotifyManager.FloatingEffectList[0].itemId, false, FrameLayer.High);
				}
				this.RefreshQueueFloatListPos();
				if (SystemNotifyManager.FloatingEffectList.Count > 0)
				{
					SystemNotifyManager.FloatingEffectList.RemoveAt(0);
				}
				if (SystemNotifyManager.FloatingImmediateEffectList.Count <= 0)
				{
					SystemNotifyManager.bPlaySound = false;
				}
			}
			this.RefreshFloatEffectListFadeOut();
			if (SystemNotifyManager.CommonAnimInterval >= 0.85f)
			{
				SystemNotifyManager.CommonAnimInterval = 0f;
				if (SystemNotifyManager.CommonAnimList.Count > 0)
				{
					SystemNotifyManager.SetCommonTextAnimationShowMode(SystemNotifyManager.CommonAnimList[0], CommonTipsDesc.eShowMode.SI_IMMEDIATELY, FrameLayer.High);
					SystemNotifyManager.CommonAnimList.RemoveAt(0);
				}
			}
			if (SystemNotifyManager.CommonAnimInterval2 >= 1.8f)
			{
				SystemNotifyManager.CommonAnimInterval2 = 0f;
				if (SystemNotifyManager.CommonAnimList2.Count > 0)
				{
					SystemNotifyManager.SetNotifyTextAnimation2ShowMode(SystemNotifyManager.CommonAnimList2[0], SystemNotifyManager.CommonAnimListcontent2[0], CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
					SystemNotifyManager.CommonAnimList2.RemoveAt(0);
					SystemNotifyManager.CommonAnimListcontent2.RemoveAt(0);
				}
			}
		}

		// Token: 0x0600AB75 RID: 43893 RVA: 0x0024C9E8 File Offset: 0x0024ADE8
		private void RefreshQueueFloatListPos()
		{
			if (SystemNotifyManager.FloatingImmediateEffectList.Count <= 0)
			{
				return;
			}
			SystemNotifyManager.FloatingImmediateEffectList2.Clear();
			if (!SystemNotifyManager.bPlaySound)
			{
				MonoSingleton<AudioManager>.instance.PlaySound(106);
				SystemNotifyManager.bPlaySound = true;
			}
			int num = 0;
			for (int i = 0; i < SystemNotifyManager.FloatingImmediateEffectList.Count; i++)
			{
				if (!(SystemNotifyManager.FloatingImmediateEffectList[i] == null))
				{
					ComCalTime component = SystemNotifyManager.FloatingImmediateEffectList[i].GetComponent<ComCalTime>();
					if (!(component == null))
					{
						RectTransform objrect = SystemNotifyManager.FloatingImmediateEffectList[i].GetComponent<RectTransform>();
						Vector3 vector = default(Vector3);
						vector = objrect.localPosition;
						if (SystemNotifyManager.FloatingEffectList.Count > 0 || !component.GetPosyIsAdded() || (component.GetPosyIsAdded() && SystemNotifyManager.FloatingImmediateEffectList.Count > 3))
						{
							vector.y += 70f;
							component.SetPosy(true);
						}
						bool flag = true;
						if (num == 0 && component.GetPassedTime() > 2.299999952316284)
						{
							vector.y += 50f;
							flag = false;
						}
						Tweener tweener = DOTween.To(() => objrect.localPosition, delegate(Vector3 r)
						{
							objrect.localPosition = r;
						}, vector, 0.5f);
						TweenSettingsExtensions.SetEase<Tweener>(tweener, 1);
						if (flag)
						{
							SystemNotifyManager.FloatingImmediateEffectList2.Add(SystemNotifyManager.FloatingImmediateEffectList[i]);
						}
						num++;
					}
				}
			}
			SystemNotifyManager.FloatingImmediateEffectList.Clear();
			for (int j = 0; j < SystemNotifyManager.FloatingImmediateEffectList2.Count; j++)
			{
				SystemNotifyManager.FloatingImmediateEffectList.Add(SystemNotifyManager.FloatingImmediateEffectList2[j]);
			}
		}

		// Token: 0x0600AB76 RID: 43894 RVA: 0x0024CBC9 File Offset: 0x0024AFC9
		private void _OnDotweenComplete(GameObject obj)
		{
			Singleton<CGameObjectPool>.instance.RecycleGameObject(obj);
		}

		// Token: 0x0600AB77 RID: 43895 RVA: 0x0024CBD6 File Offset: 0x0024AFD6
		private void RefreshFloatEffectListFadeOut()
		{
		}

		// Token: 0x0600AB78 RID: 43896 RVA: 0x0024CBD8 File Offset: 0x0024AFD8
		private static void GetItemIconBackByQuality(ref Image image, ItemTable TableData)
		{
			string path = string.Empty;
			if (TableData.Color == ItemTable.eColor.BLUE)
			{
				path = "UIPacked/pck_Common00.png:Common_itemRank_Blue";
			}
			else if (TableData.Color == ItemTable.eColor.GREEN)
			{
				path = "UIPacked/pck_Common00.png:Common_itemRank_Green";
			}
			else if (TableData.Color == ItemTable.eColor.PINK)
			{
				path = "UIPacked/pck_Common00.png:Common_itemRank_Pink";
			}
			else if (TableData.Color == ItemTable.eColor.PURPLE)
			{
				path = "UIPacked/pck_Common00.png:Common_itemRank_Purple";
			}
			else if (TableData.Color == ItemTable.eColor.YELLOW)
			{
				path = "UIPacked/pck_Common00.png:Common_itemRank_Orange";
			}
			else
			{
				path = "UIPacked/pck_Common00.png:Common_itemRank_White";
			}
			ETCImageLoader.LoadSprite(ref image, path, true);
		}

		// Token: 0x0600AB79 RID: 43897 RVA: 0x0024CC6D File Offset: 0x0024B06D
		public static void OpenCommonMsgBoxOkCancelNewFrame(CommonMsgBoxOkCancelNewParamData paramData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CommonMsgBoxOkCancelNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOkCancelNewFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonMsgBoxOkCancelNewFrame>(FrameLayer.High, paramData, string.Empty);
		}

		// Token: 0x0400600B RID: 24587
		private static SystemNotifyManager hInstance = new SystemNotifyManager();

		// Token: 0x0400600C RID: 24588
		private static float CommonAnimInterval = 0f;

		// Token: 0x0400600D RID: 24589
		private static List<string> CommonAnimList = new List<string>();

		// Token: 0x0400600E RID: 24590
		private static float CommonAnimInterval2 = 0f;

		// Token: 0x0400600F RID: 24591
		private static List<string> CommonAnimList2 = new List<string>();

		// Token: 0x04006010 RID: 24592
		private static List<string> CommonAnimListcontent2 = new List<string>();

		// Token: 0x04006011 RID: 24593
		private static float FloatingEffectInterval = 0f;

		// Token: 0x04006012 RID: 24594
		private static List<FloatEffectData> FloatingEffectList = new List<FloatEffectData>();

		// Token: 0x04006013 RID: 24595
		private static float FloatingEffectPosInterval = 0f;

		// Token: 0x04006014 RID: 24596
		private static List<string> FloatingEffectListPos = new List<string>();

		// Token: 0x04006015 RID: 24597
		private static List<GameObject> FloatingImmediateEffectList = new List<GameObject>();

		// Token: 0x04006016 RID: 24598
		private static List<GameObject> FloatingImmediateEffectList2 = new List<GameObject>();

		// Token: 0x04006017 RID: 24599
		private static int AwardNotifyCount = 0;

		// Token: 0x04006018 RID: 24600
		private static bool bPlaySound = false;

		// Token: 0x04006019 RID: 24601
		private static GameObject dungeonSkillTip = null;
	}
}
