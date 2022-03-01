using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using GameClient;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000206 RID: 518
public class Utility
{
	// Token: 0x17000203 RID: 515
	// (get) Token: 0x060010AF RID: 4271 RVA: 0x00055E91 File Offset: 0x00054291
	public static CultureInfo cultureInfo
	{
		get
		{
			return Utility.mCultureInfo;
		}
	}

	// Token: 0x060010B0 RID: 4272 RVA: 0x00055E98 File Offset: 0x00054298
	public static float I2FloatBy1000(int value)
	{
		return (float)value / (float)GlobalLogic.VALUE_1000;
	}

	// Token: 0x060010B1 RID: 4273 RVA: 0x00055EA3 File Offset: 0x000542A3
	public static float I2FloatBy10000(int value)
	{
		return (float)value / (float)GlobalLogic.VALUE_10000;
	}

	// Token: 0x060010B2 RID: 4274 RVA: 0x00055EAE File Offset: 0x000542AE
	public static float I2Float(int value)
	{
		return (float)value;
	}

	// Token: 0x060010B3 RID: 4275 RVA: 0x00055EB2 File Offset: 0x000542B2
	public static float ConvertItemDataRateValue2IntLevel(float rate)
	{
		return 5f * rate;
	}

	// Token: 0x060010B4 RID: 4276 RVA: 0x00055EBB File Offset: 0x000542BB
	public static Vec3 IRepeate2Vector(FlatBufferArray<int> value)
	{
		return new Vec3(Utility.I2FloatBy1000(value[0]), Utility.I2FloatBy1000(value[1]), 0f);
	}

	// Token: 0x060010B5 RID: 4277 RVA: 0x00055EDF File Offset: 0x000542DF
	public static Vec3 IRepeate2Vector(List<CrypticInt32> value)
	{
		return new Vec3(Utility.I2FloatBy1000(value[0]), Utility.I2FloatBy1000(value[1]), 0f);
	}

	// Token: 0x060010B6 RID: 4278 RVA: 0x00055F0D File Offset: 0x0005430D
	public static Vec3 IRepeate2Vector(List<int> value)
	{
		return new Vec3(Utility.I2FloatBy1000(value[0]), Utility.I2FloatBy1000(value[1]), 0f);
	}

	// Token: 0x060010B7 RID: 4279 RVA: 0x00055F34 File Offset: 0x00054334
	public static string GetIPAddress()
	{
		try
		{
			string hostName = Dns.GetHostName();
			IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
			if (hostEntry != null)
			{
				IPAddress[] addressList = hostEntry.AddressList;
				for (int i = 0; i < addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork)
					{
						return addressList[i].ToString();
					}
				}
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x060010B8 RID: 4280 RVA: 0x00055FB0 File Offset: 0x000543B0
	public static string GetSoundPath(Utility.SoundKind eSoundKind)
	{
		switch (eSoundKind)
		{
		case Utility.SoundKind.SK_ACCEPT_TASK:
			return "Sound/SE/quest_accept";
		case Utility.SoundKind.SK_COMPLETE_TASK:
			return "Sound/SE/qcomplete1";
		case Utility.SoundKind.SK_ABANDON_TASK:
			return "Sound/SE/qabandon";
		case Utility.SoundKind.SK_ACQUIRE_AWARD:
			return "Sound/SE/qcomplete2";
		case Utility.SoundKind.SK_OPEN_FRAME:
			return "Sound/SE/winshow";
		case Utility.SoundKind.SK_CLOSE_FRAME:
			return "Sound/SE/winclose";
		default:
			return null;
		}
	}

	// Token: 0x060010B9 RID: 4281 RVA: 0x00056008 File Offset: 0x00054408
	public static void CreateRoleActor(GeAvatarRendererEx actor, int iModeId)
	{
		if (actor == null)
		{
			Logger.LogErrorFormat("actor is null!", new object[0]);
			return;
		}
		ResTable tableItem = Singleton<TableManager>.instance.GetTableItem<ResTable>(iModeId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogErrorFormat("角色模型无法找到 ProtoTable.ResTable ID = [{0}]", new object[]
			{
				iModeId
			});
			return;
		}
		actor.LoadAvatar(tableItem.ModelPath, -1);
		actor.ChangeAction("Anim_Idle01", 1f, false);
	}

	// Token: 0x060010BA RID: 4282 RVA: 0x00056088 File Offset: 0x00054488
	public static void CreateUnitActor(GeAvatarRendererEx actor, int iUnitID, int soltID, int iWidth = 619, int iHeight = 817, bool needAureole = false)
	{
		if (actor == null)
		{
			return;
		}
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(iUnitID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			Logger.LogErrorFormat("角色模型无法找到 ProtoTable.ResTable ID = [{0}]", new object[]
			{
				tableItem.Mode
			});
			return;
		}
		actor.LoadAvatar(tableItem2.ModelPath, Utility.layerTbl[soltID]);
		actor.ChangeAction("Anim_Idle01", 1f, true);
		if (needAureole)
		{
			actor.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", true, true, false, 0f);
		}
	}

	// Token: 0x060010BB RID: 4283 RVA: 0x00056148 File Offset: 0x00054548
	public static void CreateActor(GeAvatarRendererEx actor, int iJobID, int soltID, int iWidth = 619, int iHeight = 817, bool needAureole = false)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(iJobID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogError("职业ID找不到 ID = [" + iJobID + "]\n");
			return;
		}
		if (actor == null)
		{
			Logger.LogError("actor == null ?");
			return;
		}
		ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			Logger.LogErrorFormat("角色模型无法找到 ProtoTable.ResTable ID = [{0}]", new object[]
			{
				tableItem.Mode
			});
			return;
		}
		actor.LoadAvatar(tableItem2.ModelPath, -1);
		actor.ChangeAction("Anim_Show_Idle", 1f, true);
		if (needAureole)
		{
			actor.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", true, true, false, 0f);
		}
	}

	// Token: 0x060010BC RID: 4284 RVA: 0x00056228 File Offset: 0x00054628
	public static void LoadDemoActor(GeDemoActor actor, int iJobID, bool isAsync = false)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(iJobID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogError("职业ID找不到 ID = [" + iJobID + "]\n");
			return;
		}
		if (actor == null)
		{
			Logger.LogError("actor == null ?");
			return;
		}
		ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			Logger.LogErrorFormat("角色模型无法找到 ProtoTable.ResTable ID = [{0}]", new object[]
			{
				tableItem.Mode
			});
			return;
		}
		actor.LoadAvatar(tableItem2.ModelPath, isAsync);
	}

	// Token: 0x060010BD RID: 4285 RVA: 0x000562CA File Offset: 0x000546CA
	public static bool IsStringValid(string str)
	{
		return str != null && str.Length > 0 && str != "-";
	}

	// Token: 0x060010BE RID: 4286 RVA: 0x000562EC File Offset: 0x000546EC
	public static string GetPathLastName(string fullPath)
	{
		string[] array = fullPath.Split(new char[]
		{
			'/'
		});
		return array[array.Length - 1];
	}

	// Token: 0x060010BF RID: 4287 RVA: 0x00056314 File Offset: 0x00054714
	public static bool IsDateFullDay(uint endtime, uint starttime)
	{
		uint num = endtime - starttime;
		return num >= 86399U;
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x00056330 File Offset: 0x00054730
	public static void PrintType(Type type, object obj)
	{
		string text = string.Format("Print {0}\n", type.Name);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			text += string.Format("{0}:{1}\n", fieldInfo.Name, fieldInfo.GetValue(obj));
		}
		text += "print done";
		Logger.LogError(text);
	}

	// Token: 0x060010C1 RID: 4289 RVA: 0x000563A4 File Offset: 0x000547A4
	public static string GetTypeInfoString(Type type, object obj)
	{
		string str = string.Format("Print {0}\n", type.Name);
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			str += string.Format("{0}:{1}\n", fieldInfo.Name, fieldInfo.GetValue(obj));
		}
		return str + "print done";
	}

	// Token: 0x060010C2 RID: 4290 RVA: 0x00056413 File Offset: 0x00054813
	public static void CopyRecursion<T>(GameObject src, GameObject target) where T : Component
	{
	}

	// Token: 0x060010C3 RID: 4291 RVA: 0x00056418 File Offset: 0x00054818
	public static T CopyComponent<T>(T original, GameObject destination, bool bNeedRepeat = false) where T : Component
	{
		Type type = original.GetType();
		T t = destination.GetComponent(type) as T;
		if (!bNeedRepeat)
		{
			if (!t)
			{
				t = (destination.AddComponent(type) as T);
			}
		}
		else
		{
			t = (destination.AddComponent(type) as T);
		}
		FieldInfo[] fields = type.GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (!fieldInfo.IsStatic)
			{
				fieldInfo.SetValue(t, fieldInfo.GetValue(original));
			}
		}
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (propertyInfo.CanWrite && propertyInfo.CanWrite && !(propertyInfo.Name == "name"))
			{
				propertyInfo.SetValue(t, propertyInfo.GetValue(original, null), null);
			}
		}
		return t;
	}

	// Token: 0x060010C4 RID: 4292 RVA: 0x00056554 File Offset: 0x00054954
	public static void OnPopupTaskChangedMsg(string kMsg, int iTaskID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}\t[{1}]!", kMsg, tableItem.TaskName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}
	}

	// Token: 0x060010C5 RID: 4293 RVA: 0x00056598 File Offset: 0x00054998
	public static bool SetValue(Type type, object obj, string var, int value, bool add = false)
	{
		FieldInfo field = type.GetField(var);
		if (field != null)
		{
			if (add)
			{
				field.SetValue(obj, value + (int)field.GetValue(obj));
			}
			else if (field.GetValue(obj).GetType().FullName == "System.Boolean")
			{
				field.SetValue(obj, value > 0);
			}
			else
			{
				field.SetValue(obj, value);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060010C6 RID: 4294 RVA: 0x00056628 File Offset: 0x00054A28
	public static bool SetValue2(Type type, object obj, string var, float value, bool add = false)
	{
		FieldInfo field = type.GetField(var);
		if (field != null)
		{
			if (add)
			{
				field.SetValue(obj, value + (float)field.GetValue(obj));
			}
			else if (field.GetValue(obj).GetType().FullName == "System.Boolean")
			{
				field.SetValue(obj, value > 0f);
			}
			else
			{
				field.SetValue(obj, value);
			}
			return true;
		}
		return false;
	}

	// Token: 0x060010C7 RID: 4295 RVA: 0x000566BC File Offset: 0x00054ABC
	public static bool SetValueForProperty(Type type, object obj, string var, int value, bool add = false)
	{
		PropertyInfo property = type.GetProperty(var);
		if (property != null)
		{
			int num = (int)property.GetGetMethod().Invoke(obj, null);
			if (add)
			{
				property.GetSetMethod().Invoke(obj, new object[]
				{
					value + num
				});
			}
			else
			{
				property.GetSetMethod().Invoke(obj, new object[]
				{
					value
				});
			}
			return true;
		}
		return false;
	}

	// Token: 0x060010C8 RID: 4296 RVA: 0x00056734 File Offset: 0x00054B34
	public static int GetValue(Type type, object obj, string var, bool isField = true)
	{
		int result = 0;
		try
		{
			if (isField)
			{
				FieldInfo field = type.GetField(var);
				if (field != null)
				{
					object value = field.GetValue(obj);
					if (value.GetType() == typeof(CrypticInt32))
					{
						result = (CrypticInt32)value;
					}
					else
					{
						result = (int)value;
					}
				}
			}
			else
			{
				PropertyInfo property = type.GetProperty(var);
				if (property != null)
				{
					result = (int)property.GetGetMethod().Invoke(obj, null);
				}
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat("get value error:{0} {1}", new object[]
			{
				type.Name,
				ex.ToString()
			});
		}
		return result;
	}

	// Token: 0x060010C9 RID: 4297 RVA: 0x000567F4 File Offset: 0x00054BF4
	public static bool IsFloatZero(float f)
	{
		return Mathf.Abs(f) <= 1E-06f;
	}

	// Token: 0x060010CA RID: 4298 RVA: 0x00056808 File Offset: 0x00054C08
	public static List<int> toList(List<CrypticInt32> list)
	{
		List<int> list2 = new List<int>();
		if (list != null)
		{
			for (int i = 0; i < list.Count; i++)
			{
				list2.Add(list[i]);
			}
		}
		return list2;
	}

	// Token: 0x060010CB RID: 4299 RVA: 0x0005684B File Offset: 0x00054C4B
	public static List<int> toList(List<int> list)
	{
		return list;
	}

	// Token: 0x060010CC RID: 4300 RVA: 0x00056850 File Offset: 0x00054C50
	public static GameObject FindChild(string name, GameObject parent)
	{
		if (parent == null)
		{
			return null;
		}
		Transform transform = parent.transform.Find(name);
		if (transform == null)
		{
			return null;
		}
		return transform.gameObject;
	}

	// Token: 0x060010CD RID: 4301 RVA: 0x0005688C File Offset: 0x00054C8C
	public static GameObject FindThatChild(string name, GameObject parent, bool includeInactive = false)
	{
		if (parent == null)
		{
			return null;
		}
		Transform[] componentsInChildren = parent.GetComponentsInChildren<Transform>(includeInactive);
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.name == name)
			{
				return transform.gameObject;
			}
		}
		return null;
	}

	// Token: 0x060010CE RID: 4302 RVA: 0x000568E4 File Offset: 0x00054CE4
	public static GameObject FindGameObject(string path, bool bMustExist = true)
	{
		GameObject gameObject = GameObject.Find(path);
		if (gameObject == null && bMustExist)
		{
			Logger.LogError("!!!FindGameObject Error: " + path + "\n");
		}
		return gameObject;
	}

	// Token: 0x060010CF RID: 4303 RVA: 0x00056920 File Offset: 0x00054D20
	public static GameObject FindGameObject(GameObject root, string path, bool bMustExist = true)
	{
		GameObject gameObject = null;
		if (root != null && root.transform != null)
		{
			Transform transform = root.transform.Find(path);
			if (transform != null)
			{
				gameObject = root.transform.Find(path).gameObject;
			}
			if (gameObject == null && bMustExist)
			{
				Logger.LogError("!!!FindGameObject Error: " + path + "\n");
			}
		}
		return gameObject;
	}

	// Token: 0x060010D0 RID: 4304 RVA: 0x000569A0 File Offset: 0x00054DA0
	public static int GetItemCount(ulong id)
	{
		int result = 0;
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
		if (item != null)
		{
			return item.Count;
		}
		return result;
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x060010D1 RID: 4305 RVA: 0x000569CC File Offset: 0x00054DCC
	public static List<JobTable> BettleJobIds
	{
		get
		{
			if (Utility.betterJobIds.Count == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
				if (table != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						JobTable jobTable = keyValuePair.Value as JobTable;
						if (jobTable != null && jobTable.Open == 1 && jobTable.JobType == 1)
						{
							Utility.betterJobIds.Add(jobTable);
						}
					}
				}
			}
			return Utility.betterJobIds;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x060010D2 RID: 4306 RVA: 0x00056A54 File Offset: 0x00054E54
	public static List<JobTable> OrgJobTables
	{
		get
		{
			if (Utility.ms_akAllJobsID.Count == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
				if (table != null)
				{
					foreach (KeyValuePair<int, object> keyValuePair in table)
					{
						JobTable jobTable = keyValuePair.Value as JobTable;
						if (jobTable != null && jobTable.JobType == 0 && jobTable.Open == 1)
						{
							Utility.ms_akAllJobsID.Add(jobTable);
						}
					}
				}
			}
			return Utility.ms_akAllJobsID;
		}
	}

	// Token: 0x060010D3 RID: 4307 RVA: 0x00056ADC File Offset: 0x00054EDC
	public static Vector3 GetScreen2Position(Camera camera, Vector3 postioin)
	{
		if (camera != null)
		{
			return camera.WorldToScreenPoint(postioin);
		}
		return default(Vector3);
	}

	// Token: 0x060010D4 RID: 4308 RVA: 0x00056B08 File Offset: 0x00054F08
	public static T FindComponent<T>(GameObject root, string path, bool bMustExist = true) where T : Component
	{
		GameObject gameObject = Utility.FindGameObject(root, path, bMustExist);
		if (gameObject == null)
		{
			return (T)((object)null);
		}
		T component = gameObject.GetComponent<T>();
		if (component == null)
		{
			Logger.LogError(string.Concat(new string[]
			{
				"!!!FindComponent Error: ",
				path,
				"..",
				typeof(T).ToString(),
				"\n"
			}));
		}
		return component;
	}

	// Token: 0x060010D5 RID: 4309 RVA: 0x00056B88 File Offset: 0x00054F88
	public static Component FindComponent(GameObject root, Type type, string path, bool bMustExist = true)
	{
		GameObject gameObject = Utility.FindGameObject(root, path, bMustExist);
		if (gameObject == null)
		{
			return null;
		}
		Component component = gameObject.GetComponent(type);
		if (component == null)
		{
			Logger.LogError(string.Concat(new string[]
			{
				"!!!FindComponent Error: ",
				path,
				"..",
				type.ToString(),
				"\n"
			}));
		}
		return component;
	}

	// Token: 0x060010D6 RID: 4310 RVA: 0x00056BF8 File Offset: 0x00054FF8
	public static T FindComponent<T>(string path, bool bMustExist = true) where T : Component
	{
		GameObject gameObject = Utility.FindGameObject(path, bMustExist);
		if (gameObject == null)
		{
			return (T)((object)null);
		}
		T component = gameObject.GetComponent<T>();
		if (component == null)
		{
			Logger.LogError(string.Concat(new string[]
			{
				"!!!FindComponent Error: ",
				path,
				"..",
				typeof(T).ToString(),
				"\n"
			}));
		}
		return component;
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x00056C78 File Offset: 0x00055078
	public static void AttachTo(GameObject go, GameObject parent, bool keepPos = false)
	{
		if (parent == null)
		{
			return;
		}
		if (go == null)
		{
			return;
		}
		RectTransform component = go.GetComponent<RectTransform>();
		Transform transform = go.transform;
		Vector2 offsetMin = Vector2.zero;
		Vector2 offsetMax = Vector2.zero;
		Vector2 anchorMax = Vector2.zero;
		Vector2 anchorMin = Vector2.zero;
		Vector3 localScale = transform.transform.localScale;
		Vector3 localPosition = transform.transform.localPosition;
		Quaternion localRotation = transform.transform.localRotation;
		if (component != null)
		{
			offsetMin = component.offsetMin;
			offsetMax = component.offsetMax;
			anchorMin = component.anchorMin;
			anchorMax = component.anchorMax;
		}
		go.transform.SetParent(parent.transform, true);
		transform.localScale = localScale;
		transform.localRotation = localRotation;
		transform.localPosition = localPosition;
		if (component != null)
		{
			component.offsetMin = offsetMin;
			component.offsetMax = offsetMax;
			component.anchorMin = anchorMin;
			component.anchorMax = anchorMax;
		}
	}

	// Token: 0x060010D8 RID: 4312 RVA: 0x00056D6C File Offset: 0x0005516C
	public static byte[] BytesConvert(string s)
	{
		return Encoding.UTF8.GetBytes(s.TrimEnd(new char[1]));
	}

	// Token: 0x060010D9 RID: 4313 RVA: 0x00056D84 File Offset: 0x00055184
	public static Color GetMissionTypeColor(MissionTable.eTaskType eTaskType)
	{
		Color[] array = new Color[]
		{
			new Color(254f, 197f, 0f, 255f),
			new Color(32f, 255f, 79f, 255f),
			new Color(255f, 255f, 255f, 255f),
			new Color(255f, 120f, 0f, 255f),
			new Color(255f, 120f, 0f, 255f),
			new Color(255f, 120f, 0f, 255f),
			new Color(255f, 120f, 0f, 255f),
			new Color(255f, 120f, 0f, 255f)
		};
		if (eTaskType >= MissionTable.eTaskType.TT_DIALY && eTaskType < (MissionTable.eTaskType)array.Length)
		{
			return array[(int)eTaskType];
		}
		return array[0];
	}

	// Token: 0x060010DA RID: 4314 RVA: 0x00056EEC File Offset: 0x000552EC
	public static void SetMissionTypeIcon(GameObject goTypeIcon, MissionTable.eTaskType eTaskType, bool bNeedSetNativeSize = false)
	{
		Image component = goTypeIcon.transform.GetComponent<Image>();
		if (component == null)
		{
			return;
		}
		string[] array = new string[]
		{
			"UIPacked/p-Mission.png:Taskbook_typeOutside",
			"UIPacked/p-Mission.png:Taskbook_iconMain.png",
			"UIPacked/p-Mission.png:Taskbook_typeSystem",
			"UIPacked/p-Mission.png:Taskbook_iconAchievement.png",
			"UIPacked/p-Mission.png:Taskbook_iconBranch.png",
			"UIPacked/p-Mission.png:Taskbook_typeActivity",
			"UIPacked/p-Mission.png:Taskbook_typeOutside",
			"UIPacked/p-Mission.png:Taskbook_changeJob"
		};
		if (eTaskType >= MissionTable.eTaskType.TT_DIALY && eTaskType < (MissionTable.eTaskType)array.Length)
		{
			Utility.createSprite(array[(int)eTaskType], ref component);
			if (bNeedSetNativeSize)
			{
				component.SetNativeSize();
			}
		}
	}

	// Token: 0x060010DB RID: 4315 RVA: 0x00056F80 File Offset: 0x00055380
	public static string GetNpcFunctionName(int iNpcID)
	{
		string result = "未知的职业";
		NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			result = tableItem.Function.ToString();
		}
		return result;
	}

	// Token: 0x060010DC RID: 4316 RVA: 0x00056FC5 File Offset: 0x000553C5
	private static void _TryAddDesc(ref string text, string desc)
	{
		if (!string.IsNullOrEmpty(desc))
		{
			if (string.IsNullOrEmpty(text))
			{
				text = desc;
			}
			else
			{
				text = text + "\r\n" + desc;
			}
		}
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x00056FF8 File Offset: 0x000553F8
	private static void _TryAddDesc(ref string text, List<string> desc)
	{
		for (int i = 0; i < desc.Count; i++)
		{
			Utility._TryAddDesc(ref text, desc[i]);
		}
	}

	// Token: 0x060010DE RID: 4318 RVA: 0x0005702C File Offset: 0x0005542C
	private static void _AddBlank(ref List<Utility.TipContent> tipItems, int iHeight = 20)
	{
		if (tipItems != null)
		{
			Utility.TipContent tipContent = new Utility.TipContent();
			tipContent.iParam0 = iHeight;
			tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_BLANK_DESC;
			tipItems.Add(tipContent);
		}
	}

	// Token: 0x060010DF RID: 4319 RVA: 0x00057060 File Offset: 0x00055460
	public static string _GetDifferenceDesc(int a_value0, int a_value1)
	{
		if (a_value0 == a_value1)
		{
			return string.Empty;
		}
		if (a_value0 > a_value1)
		{
			string arg = string.Format("(+{0})", a_value0 - a_value1);
			return TR.Value("color_green", arg);
		}
		string arg2 = string.Format("({0})", a_value0 - a_value1);
		return TR.Value("color_red", arg2);
	}

	// Token: 0x060010E0 RID: 4320 RVA: 0x000570C0 File Offset: 0x000554C0
	public static List<string> _GetBaseMainPropDescs(EquipProp a_Prop, EquipProp a_compareProp)
	{
		List<string> list = new List<string>();
		EEquipProp[] array = new EEquipProp[]
		{
			EEquipProp.PhysicsAttack,
			EEquipProp.MagicAttack,
			EEquipProp.PhysicsDefense,
			EEquipProp.MagicDefense
		};
		for (int i = 0; i < array.Length; i++)
		{
			string text = a_Prop.GetPropFormatStr(array[i], -1);
			if (!string.IsNullOrEmpty(text))
			{
				if (a_compareProp != null)
				{
					int num = (int)array[i];
					text += " ";
					text += Utility._GetDifferenceDesc(a_Prop.props[num], a_compareProp.props[num]);
				}
				list.Add(text);
			}
		}
		return list;
	}

	// Token: 0x060010E1 RID: 4321 RVA: 0x00057168 File Offset: 0x00055568
	public static List<Utility.TipContent> GetTitleTipItemList(ItemData item)
	{
		List<Utility.TipContent> list = new List<Utility.TipContent>();
		Utility.TipContent tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_BASEATTR;
		Utility._TryAddDesc(ref tipContent.left, item.GetLevelLimitDesc());
		Utility._TryAddDesc(ref tipContent.left, item.GetTimeLeftDesc());
		Utility._TryAddDesc(ref tipContent.left, item.GetOccupationLimitDesc());
		Utility._TryAddDesc(ref tipContent.right, item.GetQualityDesc());
		Utility._TryAddDesc(ref tipContent.right, item.GetBindStateDesc());
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_STRENGTH_DESC;
		Utility._TryAddDesc(ref tipContent.left, item.GetStrengthenDescs());
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_PHYSIC_ATTACK;
		Utility._TryAddDesc(ref tipContent.left, Utility._GetBaseMainPropDescs(item.BaseProp, null));
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_FOUR_ATTR;
		Utility._TryAddDesc(ref tipContent.left, item.GetFourAttrDescs());
		Utility._TryAddDesc(ref tipContent.left, item.GetBeadDescs());
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_ATTACH_ATTR;
		Utility._TryAddDesc(ref tipContent.left, item.GetAttachAttrDescs());
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_COM_ATTR;
		Utility._TryAddDesc(ref tipContent.left, item.GetComplexAttrDescs());
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_TIMESTAMP_ATTR;
		Utility._TryAddDesc(ref tipContent.left, item.GetDeadTimestampDesc());
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
			Utility._AddBlank(ref list, 20);
		}
		tipContent = new Utility.TipContent();
		tipContent.ETipContentType = Utility.TipContent.TipContentType.TCT_INTERESTING_DESC;
		Utility._TryAddDesc(ref tipContent.left, item.Description);
		if (!tipContent.IsNull)
		{
			list.Add(tipContent);
		}
		while (list.Count > 0 && list[list.Count - 1].ETipContentType == Utility.TipContent.TipContentType.TCT_BLANK_DESC)
		{
			list.RemoveAt(list.Count - 1);
		}
		return list;
	}

	// Token: 0x060010E2 RID: 4322 RVA: 0x000573D8 File Offset: 0x000557D8
	public static Utility.ContentProcess ParseMissionProcess(int taskId, bool bCondition = false)
	{
		string content = string.Empty;
		int num = 0;
		int num2 = 0;
		Utility.ContentProcess contentProcess = new Utility.ContentProcess();
		MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)taskId);
		if (mission != null)
		{
			string[] array = null;
			string text;
			if (mission.status == 0)
			{
				text = mission.missionItem.TaskInitText;
			}
			else if (mission.status == 1)
			{
				text = mission.missionItem.TaskAcceptedText;
			}
			else
			{
				text = mission.missionItem.TaskFinishText;
			}
			if (!bCondition)
			{
				array = (mission.missionItem.TaskInformationText + "\n" + text).ToString().Split(new char[]
				{
					'\r',
					'\n'
				});
			}
			else
			{
				array = text.ToString().Split(new char[]
				{
					'\r',
					'\n'
				});
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			for (int i = 0; i < array.Length; i++)
			{
				int num3 = 0;
				for (int j = 0; j < 3; j++)
				{
					IEnumerator enumerator = Utility.ms_missionkey_regex[j].Matches(array[i]).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Match match = (Match)obj;
							stringBuilder.Append(array[i].Substring(num3, match.Index - num3));
							Utility.MissionKeyType missionKeyType = (Utility.MissionKeyType)j;
							if (missionKeyType != Utility.MissionKeyType.MKT_KEY)
							{
								if (missionKeyType != Utility.MissionKeyType.MKT_KEY_VALUE)
								{
									if (missionKeyType == Utility.MissionKeyType.MKT_KEY_KEY)
									{
										int num4 = 0;
										int num5 = 0;
										string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
										string missionValueByKey2 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[2].Value);
										try
										{
											num4 = int.Parse(missionValueByKey);
											num5 = int.Parse(missionValueByKey2);
										}
										catch (Exception ex)
										{
											string text2 = string.Format("[Task ParseMissionText]Task ID {0} TaskInfo Key0 [{1}] Key1 [{2}] to Int Error \n {3}", new object[]
											{
												taskId,
												match.Groups[1].Value,
												match.Groups[2].Value,
												array[i]
											});
											goto IL_3A4;
										}
										if (num4 >= num5)
										{
											stringBuilder.Append("<color=grey>");
										}
										else
										{
											stringBuilder.Append("<color=white>");
										}
										stringBuilder.AppendFormat("{0}/{1}", num4, num5);
										stringBuilder.Append("</Color>");
										num += num4;
										num2 += num5;
									}
								}
								else
								{
									int num6 = 0;
									int num7 = 0;
									string missionValueByKey3 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
									try
									{
										num6 = int.Parse(missionValueByKey3);
										num7 = int.Parse(match.Groups[2].Value);
									}
									catch (Exception ex2)
									{
										string text3 = string.Format("[Task ParseMissionText]Task ID {0} TaskInfo Key [{1}] Parse Value [{2}] to Int Error \n {3}", new object[]
										{
											taskId,
											match.Groups[1].Value,
											match.Groups[2].Value,
											array[i]
										});
										goto IL_3A4;
									}
									if (num6 >= num7)
									{
										stringBuilder.Append("<color=grey>");
									}
									else
									{
										stringBuilder.Append("<color=white>");
									}
									stringBuilder.AppendFormat("{0}/{1}", num6, num7);
									stringBuilder.Append("</Color>");
									num += num6;
									num2 += num7;
								}
							}
							else
							{
								string missionValueByKey4 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
								if (!string.IsNullOrEmpty(missionValueByKey4))
								{
									stringBuilder.Append(missionValueByKey4);
								}
							}
							IL_3A4:
							num3 = match.Index + match.Length;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				stringBuilder.Append(array[i].Substring(num3, array[i].Length - num3));
				if (i != array.Length - 1)
				{
					stringBuilder.Append("\r\n");
				}
			}
			content = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
		}
		contentProcess.iAftValue = num2;
		contentProcess.iPreValue = num;
		contentProcess.content = content;
		contentProcess.fAmount = ((num2 > 0) ? ((float)num * 1f / (float)num2) : 1f);
		contentProcess.bFinish = (num2 <= num);
		return contentProcess;
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x000578BC File Offset: 0x00055CBC
	public static Utility.DailyProveTaskConfig GetDailyProveTaskConfig(int taskId)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(taskId, string.Empty, string.Empty);
		if (tableItem != null && !string.IsNullOrEmpty(tableItem.TaskFinishText))
		{
			string[] array = tableItem.TaskFinishText.Split(new char[]
			{
				':'
			});
			if (array.Length == 2)
			{
				Match match = Utility.ms_missionkey_regex[1].Match(array[1]);
				if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value))
				{
					string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
					try
					{
						int iPreValue = int.Parse(missionValueByKey);
						int iAftValue = int.Parse(match.Groups[2].Value);
						return new Utility.DailyProveTaskConfig
						{
							title = array[0],
							iPreValue = iPreValue,
							iAftValue = iAftValue
						};
					}
					catch (Exception ex)
					{
					}
				}
			}
		}
		return null;
	}

	// Token: 0x060010E4 RID: 4324 RVA: 0x000579D4 File Offset: 0x00055DD4
	public static string ParseMissionTextForMissionInfo(MissionInfo missionInfo, bool bCondition = false, bool bMarkDefault = false, bool onlySchedule = false)
	{
		bool flag = false;
		MissionManager.SingleMissionInfo singleMissionInfo = new MissionManager.SingleMissionInfo();
		singleMissionInfo.taskID = missionInfo.taskID;
		singleMissionInfo.status = missionInfo.status;
		singleMissionInfo.finTime = missionInfo.finTime;
		singleMissionInfo.submitCount = missionInfo.submitCount;
		singleMissionInfo.missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
		string result = string.Empty;
		MissionManager.SingleMissionInfo singleMissionInfo2 = singleMissionInfo;
		if (singleMissionInfo2 != null)
		{
			string text;
			if (singleMissionInfo2.status == 0)
			{
				text = singleMissionInfo2.missionItem.TaskInitText;
			}
			else if (singleMissionInfo2.status == 1)
			{
				text = singleMissionInfo2.missionItem.TaskAcceptedText;
			}
			else
			{
				text = singleMissionInfo2.missionItem.TaskFinishText;
			}
			string[] array = null;
			if (!bCondition)
			{
				array = (singleMissionInfo2.missionItem.TaskInformationText + "\n" + text).ToString().Split(new char[]
				{
					'\r',
					'\n'
				});
			}
			else
			{
				array = text.ToString().Split(new char[]
				{
					'\r',
					'\n'
				});
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			string str = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				if (!onlySchedule || i < 1)
				{
					int num = 0;
					for (int j = 0; j < 3; j++)
					{
						IEnumerator enumerator = Utility.ms_missionkey_regex[j].Matches(array[i]).GetEnumerator();
						try
						{
							while (enumerator.MoveNext())
							{
								object obj = enumerator.Current;
								Match match = (Match)obj;
								stringBuilder.Append(array[i].Substring(num, match.Index - num));
								Utility.MissionKeyType missionKeyType = (Utility.MissionKeyType)j;
								if (missionKeyType != Utility.MissionKeyType.MKT_KEY)
								{
									if (missionKeyType != Utility.MissionKeyType.MKT_KEY_VALUE)
									{
										if (missionKeyType == Utility.MissionKeyType.MKT_KEY_KEY)
										{
											int num2 = 0;
											int num3 = 0;
											string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey(missionInfo.taskID, match.Groups[1].Value);
											string missionValueByKey2 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey(missionInfo.taskID, match.Groups[2].Value);
											try
											{
												num2 = int.Parse(missionValueByKey);
												num3 = int.Parse(missionValueByKey2);
											}
											catch (Exception ex)
											{
												string text2 = string.Format("[Task ParseMissionText]Task ID {0} TaskInfo Key0 [{1}] Key1 [{2}] to Int Error \n {3}", new object[]
												{
													missionInfo.taskID,
													match.Groups[1].Value,
													match.Groups[2].Value,
													array[i]
												});
												goto IL_45C;
											}
											if (num2 >= num3)
											{
												flag = true;
												stringBuilder.Append("<color=grey>");
											}
											else
											{
												stringBuilder.Append("<color=white>");
											}
											stringBuilder.AppendFormat("{0}/{1}", num2, num3);
											stringBuilder.Append("</Color>");
											str = string.Format("{0}/{1}", num2, num3);
										}
									}
									else
									{
										string s = "0";
										for (int k = 0; k < missionInfo.akMissionPairs.Length; k++)
										{
											if (missionInfo.akMissionPairs[k].key == match.Groups[1].Value)
											{
												s = missionInfo.akMissionPairs[k].value;
											}
										}
										int num4 = int.Parse(s);
										int num5 = int.Parse(match.Groups[2].Value);
										if (bMarkDefault)
										{
											num4 = num5;
										}
										if (num4 >= num5)
										{
											flag = true;
											stringBuilder.Append("<color=grey>");
										}
										else
										{
											stringBuilder.Append("<color=white>");
										}
										stringBuilder.AppendFormat("{0}/{1}", num4, num5);
										stringBuilder.Append("</Color>");
										str = string.Format("{0}/{1}", num4, num5);
									}
								}
								else
								{
									string value = "0";
									for (int l = 0; l < missionInfo.akMissionPairs.Length; l++)
									{
										if (missionInfo.akMissionPairs[l].key == match.Groups[1].Value)
										{
											value = missionInfo.akMissionPairs[l].value;
										}
									}
									if (!string.IsNullOrEmpty(value))
									{
										stringBuilder.Append(value);
									}
								}
								IL_45C:
								num = match.Index + match.Length;
							}
						}
						finally
						{
							IDisposable disposable;
							if ((disposable = (enumerator as IDisposable)) != null)
							{
								disposable.Dispose();
							}
						}
					}
					stringBuilder.Append(array[i].Substring(num, array[i].Length - num));
					if (i != array.Length - 1)
					{
						stringBuilder.Append("\r\n");
					}
				}
			}
			if (onlySchedule)
			{
				result = string.Empty + str;
			}
			else
			{
				result = stringBuilder.ToString();
				StringBuilderCache.Release(stringBuilder);
			}
		}
		if (flag)
		{
			return "已完成";
		}
		return result;
	}

	// Token: 0x060010E5 RID: 4325 RVA: 0x00057F38 File Offset: 0x00056338
	public static string ParseMissionText(int taskId, bool bCondition = false, bool bMarkDefault = false, bool onlySchedule = false)
	{
		string result = string.Empty;
		MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)taskId);
		if (mission != null)
		{
			string text;
			if (mission.status == 0)
			{
				text = mission.missionItem.TaskInitText;
			}
			else if (mission.status == 1)
			{
				text = mission.missionItem.TaskAcceptedText;
			}
			else
			{
				text = mission.missionItem.TaskFinishText;
			}
			if (mission.missionItem.SubType == MissionTable.eSubType.SummerNpc && (mission.status == 1 || mission.status == 0))
			{
				string missionNpcName = DataManager<AttackCityMonsterDataManager>.GetInstance().GetMissionNpcName(mission.taskContents);
				return string.Format(text, missionNpcName);
			}
			string[] array = null;
			if (!bCondition)
			{
				array = (mission.missionItem.TaskInformationText + "\n" + text).ToString().Split(new char[]
				{
					'\r',
					'\n'
				});
			}
			else
			{
				array = text.ToString().Split(new char[]
				{
					'\r',
					'\n'
				});
			}
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			for (int i = 0; i < array.Length; i++)
			{
				int num = 0;
				for (int j = 0; j < 3; j++)
				{
					IEnumerator enumerator = Utility.ms_missionkey_regex[j].Matches(array[i]).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Match match = (Match)obj;
							stringBuilder.Append(array[i].Substring(num, match.Index - num));
							Utility.MissionKeyType missionKeyType = (Utility.MissionKeyType)j;
							if (missionKeyType != Utility.MissionKeyType.MKT_KEY)
							{
								if (missionKeyType != Utility.MissionKeyType.MKT_KEY_VALUE)
								{
									if (missionKeyType == Utility.MissionKeyType.MKT_KEY_KEY)
									{
										int num2 = 0;
										int num3 = 0;
										string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
										string missionValueByKey2 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[2].Value);
										try
										{
											num2 = int.Parse(missionValueByKey);
											num3 = int.Parse(missionValueByKey2);
										}
										catch (Exception ex)
										{
											string text2 = string.Format("[Task ParseMissionText]Task ID {0} TaskInfo Key0 [{1}] Key1 [{2}] to Int Error \n {3}", new object[]
											{
												taskId,
												match.Groups[1].Value,
												match.Groups[2].Value,
												array[i]
											});
											goto IL_3C7;
										}
										if (num2 >= num3)
										{
											stringBuilder.Append("<color=grey>");
										}
										else
										{
											stringBuilder.Append("<color=white>");
										}
										stringBuilder.AppendFormat("{0}/{1}", num2, num3);
										stringBuilder.Append("</Color>");
									}
								}
								else
								{
									int num4 = 0;
									int num5 = 0;
									string missionValueByKey3 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
									try
									{
										num4 = int.Parse(missionValueByKey3);
										num5 = int.Parse(match.Groups[2].Value);
									}
									catch (Exception ex2)
									{
										string text3 = string.Format("[Task ParseMissionText]Task ID {0} TaskInfo Key [{1}] Parse Value [{2}] to Int Error \n {3}", new object[]
										{
											taskId,
											match.Groups[1].Value,
											match.Groups[2].Value,
											array[i]
										});
										goto IL_3C7;
									}
									if (bMarkDefault)
									{
										num4 = num5;
									}
									if (num4 >= num5)
									{
										stringBuilder.Append("<color=grey>");
									}
									else
									{
										stringBuilder.Append("<color=white>");
									}
									stringBuilder.AppendFormat("{0}/{1}", num4, num5);
									stringBuilder.Append("</Color>");
								}
							}
							else
							{
								string missionValueByKey4 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)taskId, match.Groups[1].Value);
								if (!string.IsNullOrEmpty(missionValueByKey4))
								{
									stringBuilder.Append(missionValueByKey4);
								}
							}
							IL_3C7:
							num = match.Index + match.Length;
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				stringBuilder.Append(array[i].Substring(num, array[i].Length - num));
				if (i != array.Length - 1)
				{
					stringBuilder.Append("\r\n");
				}
			}
			result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
		}
		return result;
	}

	// Token: 0x060010E6 RID: 4326 RVA: 0x000583FC File Offset: 0x000567FC
	public static void SetMissionTypeIcon(Image imgTypeIcon, MissionTable.eTaskType eTaskType, bool bNeedSetNativeSize = false)
	{
		if (imgTypeIcon == null)
		{
			return;
		}
		string[] array = new string[]
		{
			"UI/Image/Mission/Taskbook_typeOutside",
			"UI/Image/Mission/Taskbook_typeMain",
			"UI/Image/Mission/Taskbook_typeSystem",
			"UI/Image/Mission/Taskbook_typeAchievement",
			"UI/Image/Mission/Taskbook_typeOutside",
			"UI/Image/Mission/Taskbook_typeActivity",
			"UI/Image/Mission/Taskbook_typeOutside"
		};
		if (eTaskType >= MissionTable.eTaskType.TT_DIALY && eTaskType < (MissionTable.eTaskType)array.Length)
		{
			ETCImageLoader.LoadSprite(ref imgTypeIcon, array[(int)eTaskType], true);
			if (bNeedSetNativeSize)
			{
				imgTypeIcon.SetNativeSize();
			}
		}
	}

	// Token: 0x060010E7 RID: 4327 RVA: 0x00058480 File Offset: 0x00056880
	public static void SetImageIcon(GameObject goImage, string icon, bool bSetNativeSize = false)
	{
		if (goImage != null)
		{
			Image component = goImage.GetComponent<Image>();
			if (component != null)
			{
				ETCImageLoader.LoadSprite(ref component, icon, true);
				if (bSetNativeSize)
				{
					component.SetNativeSize();
				}
			}
		}
	}

	// Token: 0x060010E8 RID: 4328 RVA: 0x000584C4 File Offset: 0x000568C4
	public static void SetChildTextContent(Transform parent, string name, string content, bool bVisble = true)
	{
		if (parent != null && name != null)
		{
			Transform transform = parent.Find(name);
			if (transform != null)
			{
				Text component = transform.GetComponent<Text>();
				if (component != null)
				{
					component.gameObject.SetActive(bVisble);
					component.text = content;
				}
			}
		}
	}

	// Token: 0x060010E9 RID: 4329 RVA: 0x00058520 File Offset: 0x00056920
	public static void BindCachedNetMsg<T>(T target, MessageEvents msgEvents)
	{
		MethodInfo[] methods = target.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		List<MessageHandleAttribute> list = null;
		for (int i = 0; i < methods.Length; i++)
		{
			object[] customAttributes = methods[i].GetCustomAttributes(typeof(MessageHandleAttribute), false);
			if (customAttributes.Length > 0)
			{
				MessageHandleAttribute messageHandleAttribute = customAttributes[0] as MessageHandleAttribute;
				if (messageHandleAttribute != null && messageHandleAttribute.bNeedCache)
				{
					if (list == null)
					{
						list = new List<MessageHandleAttribute>();
					}
					list.Add(messageHandleAttribute);
				}
			}
		}
		if (list != null)
		{
			list.Sort((MessageHandleAttribute x, MessageHandleAttribute y) => x.order - y.order);
			for (int j = 0; j < list.Count; j++)
			{
				msgEvents.AddMessage(list[j].id, true);
			}
		}
	}

	// Token: 0x060010EA RID: 4330 RVA: 0x000585F0 File Offset: 0x000569F0
	public static void UnBindCachedNetMsg<T>(T target, MessageEvents msgEvents)
	{
		List<Utility.OrderMethod> list = null;
		Type type = target.GetType();
		MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		for (int i = 0; i < methods.Length; i++)
		{
			object[] customAttributes = methods[i].GetCustomAttributes(typeof(MessageHandleAttribute), false);
			if (customAttributes.Length > 0)
			{
				MessageHandleAttribute messageHandleAttribute = customAttributes[0] as MessageHandleAttribute;
				if (messageHandleAttribute.bNeedCache)
				{
					List<MsgDATA> messageDatas = msgEvents.GetMessageDatas(messageHandleAttribute.id);
					if (messageDatas != null && messageDatas.Count > 0)
					{
						if (list == null)
						{
							list = new List<Utility.OrderMethod>();
						}
						list.Add(new Utility.OrderMethod
						{
							attr = messageHandleAttribute,
							datas = messageDatas,
							method = methods[i],
							target = target
						});
					}
				}
			}
		}
		if (list != null)
		{
			list.Sort((Utility.OrderMethod x, Utility.OrderMethod y) => x.attr.order - y.attr.order);
			for (int j = 0; j < list.Count; j++)
			{
				list[j].Invoke();
			}
		}
	}

	// Token: 0x060010EB RID: 4331 RVA: 0x00058708 File Offset: 0x00056B08
	public static void SetChildTextColor(Transform parent, string name, Color color)
	{
		if (parent != null)
		{
			Transform transform = parent.Find(name);
			if (transform != null)
			{
				Text component = transform.GetComponent<Text>();
				if (component != null)
				{
					component.color = color;
				}
			}
		}
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x00058750 File Offset: 0x00056B50
	public static object BytesToObject(byte[] Bytes)
	{
		object result;
		using (MemoryStream memoryStream = new MemoryStream(Bytes))
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();
			result = binaryFormatter.Deserialize(memoryStream);
		}
		return result;
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x00058798 File Offset: 0x00056B98
	public static Utility.NameResult CheckRoleName(string inputName)
	{
		int byteCount = Utility.GetByteCount(inputName);
		bool flag = true;
		if (string.IsNullOrEmpty(inputName))
		{
			return Utility.NameResult.Null;
		}
		for (int i = 0; i < inputName.Length; i++)
		{
			if (!Utility.IsQuanjiaoChar(inputName.Substring(i, 1)))
			{
				flag = false;
			}
		}
		if (flag)
		{
			if (byteCount > Utility.MAX_CHINESE_NAME_LEN || byteCount < Utility.MIN_CHINESE_NAME_LEN)
			{
				return Utility.NameResult.OutOfLength;
			}
		}
		else if (byteCount > Utility.MAX_EN_NAME_LEN || byteCount < Utility.MIN_EN_NAME_LEN)
		{
			return Utility.NameResult.OutOfLength;
		}
		return Utility.NameResult.Vaild;
	}

	// Token: 0x060010EE RID: 4334 RVA: 0x00058824 File Offset: 0x00056C24
	public static string CreateMD5Hash(string input)
	{
		MD5 md = MD5.Create();
		byte[] bytes = Encoding.ASCII.GetBytes(input);
		byte[] array = md.ComputeHash(bytes);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < array.Length; i++)
		{
			stringBuilder.Append(array[i].ToString("X2"));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x060010EF RID: 4335 RVA: 0x00058888 File Offset: 0x00056C88
	public static string DateTimeFormatString(DateTime dt, Utility.enDTFormate fm)
	{
		if (fm == Utility.enDTFormate.DATE)
		{
			return string.Format("{0:D4}-{1:D2}-{2:D2}", dt.Year, dt.Month, dt.Day);
		}
		if (fm == Utility.enDTFormate.TIME)
		{
			return string.Format("{0:D2}:{1:D2}:{2:D2}", dt.Hour, dt.Minute, dt.Second);
		}
		return string.Format("{0:D4}-{1:D2}-{2:D2}", dt.Year, dt.Month, dt.Day) + " " + string.Format("{0:D2}:{1:D2}:{2:D2}", dt.Hour, dt.Minute, dt.Second);
	}

	// Token: 0x060010F0 RID: 4336 RVA: 0x00058968 File Offset: 0x00056D68
	public static GameObject FindChild(GameObject p, string path)
	{
		if (p != null)
		{
			Transform transform = p.transform.Find(path);
			return (!(transform == null)) ? transform.gameObject : null;
		}
		return null;
	}

	// Token: 0x060010F1 RID: 4337 RVA: 0x000589A8 File Offset: 0x00056DA8
	public static GameObject FindChildByName(Component component, string childpath)
	{
		return Utility.FindChildByName(component.gameObject, childpath);
	}

	// Token: 0x060010F2 RID: 4338 RVA: 0x000589B8 File Offset: 0x00056DB8
	public static GameObject FindChildByName(GameObject root, string childpath)
	{
		GameObject result = null;
		char[] separator = new char[]
		{
			'/'
		};
		string[] array = childpath.Split(separator);
		GameObject gameObject = root;
		foreach (string b in array)
		{
			bool flag = false;
			IEnumerator enumerator = gameObject.transform.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object obj = enumerator.Current;
					Transform transform = (Transform)obj;
					if (transform.gameObject.name == b)
					{
						gameObject = transform.gameObject;
						flag = true;
						break;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable == null)
				{
				}
				disposable.Dispose();
			}
			if (!flag)
			{
				break;
			}
		}
		if (gameObject != root)
		{
			result = gameObject;
		}
		return result;
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x00058AA0 File Offset: 0x00056EA0
	public static GameObject FindChildSafe(GameObject p, string path)
	{
		if (p != null)
		{
			Transform transform = p.transform.Find(path);
			if (transform != null)
			{
				return transform.gameObject;
			}
		}
		return null;
	}

	// Token: 0x060010F4 RID: 4340 RVA: 0x00058ADA File Offset: 0x00056EDA
	public static float FrameToTime(int frame)
	{
		return (float)frame * Time.fixedDeltaTime;
	}

	// Token: 0x060010F5 RID: 4341 RVA: 0x00058AE4 File Offset: 0x00056EE4
	public static int GetByteCount(string inputStr)
	{
		int num = 0;
		for (int i = 0; i < inputStr.Length; i++)
		{
			if (Utility.IsQuanjiaoChar(inputStr.Substring(i, 1)))
			{
				num += 2;
			}
			else
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060010F6 RID: 4342 RVA: 0x00058B2C File Offset: 0x00056F2C
	public static T GetComponetInChild<T>(GameObject p, string path) where T : Component
	{
		if (p == null || p.transform == null)
		{
			return (T)((object)null);
		}
		Transform transform = p.transform.Find(path);
		if (transform == null)
		{
			return (T)((object)null);
		}
		return transform.GetComponent<T>();
	}

	// Token: 0x060010F7 RID: 4343 RVA: 0x00058B84 File Offset: 0x00056F84
	private static int GetCpuClock(string cpuFile)
	{
		string fileContent = Utility.getFileContent(cpuFile);
		int num = 0;
		if (!int.TryParse(fileContent, out num))
		{
			num = 0;
		}
		return Mathf.FloorToInt((float)(num / 1000));
	}

	// Token: 0x060010F8 RID: 4344 RVA: 0x00058BB8 File Offset: 0x00056FB8
	public static int ToInt(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0;
		}
		int result = 0;
		int.TryParse(text, out result);
		return result;
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x00058BE0 File Offset: 0x00056FE0
	public static uint ToUInt(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0U;
		}
		uint result = 0U;
		uint.TryParse(text, out result);
		return result;
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x00058C08 File Offset: 0x00057008
	public static long ToLong(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0L;
		}
		long result = 0L;
		long.TryParse(text, out result);
		return result;
	}

	// Token: 0x060010FB RID: 4347 RVA: 0x00058C30 File Offset: 0x00057030
	public static ulong ToULong(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return 0UL;
		}
		ulong result = 0UL;
		ulong.TryParse(text, out result);
		return result;
	}

	// Token: 0x060010FC RID: 4348 RVA: 0x00058C58 File Offset: 0x00057058
	public static int GetCpuCurrentClock()
	{
		return Utility.GetCpuClock("/sys/devices/system/cpu/cpu0/cpufreq/scaling_cur_freq");
	}

	// Token: 0x060010FD RID: 4349 RVA: 0x00058C64 File Offset: 0x00057064
	public static int GetCpuMaxClock()
	{
		return Utility.GetCpuClock("/sys/devices/system/cpu/cpu0/cpufreq/cpuinfo_max_freq");
	}

	// Token: 0x060010FE RID: 4350 RVA: 0x00058C70 File Offset: 0x00057070
	public static int GetCpuMinClock()
	{
		return Utility.GetCpuClock("/sys/devices/system/cpu/cpu0/cpufreq/cpuinfo_min_freq");
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x00058C7C File Offset: 0x0005707C
	private static string getFileContent(string path)
	{
		string result;
		try
		{
			result = File.ReadAllText(path);
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.Message);
			result = null;
		}
		return result;
	}

	// Token: 0x06001100 RID: 4352 RVA: 0x00058CBC File Offset: 0x000570BC
	public static Vector3 GetGameObjectSize(GameObject obj)
	{
		Vector3 result = Vector3.zero;
		if (obj.GetComponent<Renderer>() != null)
		{
			result = obj.GetComponent<Renderer>().bounds.size;
		}
		foreach (Renderer renderer in obj.GetComponentsInChildren<Renderer>())
		{
			Vector3 size = renderer.bounds.size;
			result.x = Math.Max(result.x, size.x);
			result.y = Math.Max(result.y, size.y);
			result.z = Math.Max(result.z, size.z);
		}
		return result;
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x00058D78 File Offset: 0x00057178
	public static uint GetNewDayDeltaSec(int nowSec)
	{
		DateTime d = Utility.ToUtcTime2Local((long)nowSec);
		DateTime dateTime = new DateTime(d.Year, d.Month, d.Day, 0, 0, 0, DateTimeKind.Utc);
		return (uint)(dateTime.AddSeconds(86400.0) - d).TotalSeconds;
	}

	// Token: 0x06001102 RID: 4354 RVA: 0x00058DCC File Offset: 0x000571CC
	public static Type GetType(string typeName)
	{
		if (!string.IsNullOrEmpty(typeName))
		{
			Type type = Type.GetType(typeName);
			if (type != null)
			{
				return type;
			}
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				type = assembly.GetType(typeName);
				if (type != null)
				{
					return type;
				}
			}
		}
		return null;
	}

	// Token: 0x06001103 RID: 4355 RVA: 0x00058E28 File Offset: 0x00057228
	public static long GetZeroBaseSecond(long utcSec)
	{
		DateTime d = new DateTime(1970, 1, 1);
		DateTime dateTime = d.AddTicks((utcSec + 28800L) * 10000000L);
		DateTime d2 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
		return (long)(d2 - d).TotalSeconds - 28800L;
	}

	// Token: 0x06001104 RID: 4356 RVA: 0x00058E90 File Offset: 0x00057290
	public static int Hours2Second(int hour)
	{
		return hour * 60 * 60;
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x00058E9C File Offset: 0x0005729C
	public static bool IsChineseChar(char key)
	{
		int num = Convert.ToInt32(key);
		return num >= Utility.CHINESE_CHAR_START && num <= Utility.CHINESE_CHAR_END;
	}

	// Token: 0x06001106 RID: 4358 RVA: 0x00058ECC File Offset: 0x000572CC
	public static bool IsOverOneDay(int timeSpanSeconds)
	{
		TimeSpan timeSpan = new TimeSpan((long)timeSpanSeconds * 10000000L);
		return timeSpan.Days > 0;
	}

	// Token: 0x06001107 RID: 4359 RVA: 0x00058EF3 File Offset: 0x000572F3
	public static bool IsQuanjiaoChar(string inputStr)
	{
		return Encoding.Default.GetByteCount(inputStr) > 1;
	}

	// Token: 0x06001108 RID: 4360 RVA: 0x00058F03 File Offset: 0x00057303
	public static bool IsSpecialChar(char key)
	{
		return !Utility.IsChineseChar(key) && !char.IsLetter(key) && !char.IsNumber(key);
	}

	// Token: 0x06001109 RID: 4361 RVA: 0x00058F28 File Offset: 0x00057328
	public static bool IsValidText(string text)
	{
		for (int i = 0; i < text.Length; i++)
		{
			if (Utility.IsSpecialChar(text[i]))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600110A RID: 4362 RVA: 0x00058F60 File Offset: 0x00057360
	public static int Minutes2Seconds(int min)
	{
		return min * 60;
	}

	// Token: 0x0600110B RID: 4363 RVA: 0x00058F68 File Offset: 0x00057368
	public static byte[] ObjectToBytes(object obj)
	{
		byte[] buffer;
		using (MemoryStream memoryStream = new MemoryStream())
		{
			new BinaryFormatter().Serialize(memoryStream, obj);
			buffer = memoryStream.GetBuffer();
		}
		return buffer;
	}

	// Token: 0x0600110C RID: 4364 RVA: 0x00058FB4 File Offset: 0x000573B4
	public static byte[] ReadFile(string path)
	{
		FileStream fileStream = null;
		if (CFileManager.IsFileExist(path))
		{
			try
			{
				fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
				int num = (int)fileStream.Length;
				byte[] array = new byte[num];
				fileStream.Read(array, 0, num);
				fileStream.Close();
				fileStream.Dispose();
				return array;
			}
			catch (Exception)
			{
				if (fileStream != null)
				{
					fileStream.Close();
					fileStream.Dispose();
				}
			}
		}
		return null;
	}

	// Token: 0x0600110D RID: 4365 RVA: 0x00059030 File Offset: 0x00057430
	public static byte[] SByteArrToByte(sbyte[] p)
	{
		byte[] array = new byte[p.Length];
		for (int i = 0; i < p.Length; i++)
		{
			array[i] = (byte)p[i];
		}
		return array;
	}

	// Token: 0x0600110E RID: 4366 RVA: 0x00059064 File Offset: 0x00057464
	public static DateTime SecondsToDateTime(int y, int m, int d, int secondsInDay)
	{
		int hour = secondsInDay / 3600;
		secondsInDay %= 3600;
		return new DateTime(y, m, d, hour, secondsInDay / 60, secondsInDay % 60);
	}

	// Token: 0x0600110F RID: 4367 RVA: 0x00059094 File Offset: 0x00057494
	public static string SecondsToTimeText(uint secs)
	{
		uint num = secs / 3600U;
		secs -= num * 3600U;
		uint num2 = secs / 60U;
		secs -= num2 * 60U;
		return string.Format("{0:D2}:{1:D2}:{2:D2}", num, num2, secs);
	}

	// Token: 0x06001110 RID: 4368 RVA: 0x000590E0 File Offset: 0x000574E0
	public static void SetChildrenActive(GameObject root, bool active)
	{
		IEnumerator enumerator = root.transform.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				Transform transform = (Transform)obj;
				if (transform != root.transform)
				{
					transform.gameObject.SetActive(active);
				}
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable == null)
			{
			}
			disposable.Dispose();
		}
	}

	// Token: 0x06001111 RID: 4369 RVA: 0x0005915C File Offset: 0x0005755C
	public static void StringToByteArray(string str, ref byte[] buffer)
	{
		byte[] bytes = Encoding.Default.GetBytes(str);
		Array.Copy(bytes, buffer, Math.Min(bytes.Length, buffer.Length));
		buffer[buffer.Length - 1] = 0;
	}

	// Token: 0x06001112 RID: 4370 RVA: 0x00059194 File Offset: 0x00057594
	public static DateTime StringToDateTime(string dtStr, DateTime defaultIfNone)
	{
		ulong dtVal;
		if (ulong.TryParse(dtStr, out dtVal))
		{
			return Utility.ULongToDateTime(dtVal);
		}
		return defaultIfNone;
	}

	// Token: 0x06001113 RID: 4371 RVA: 0x000591B6 File Offset: 0x000575B6
	public static int TimeToFrame(float time)
	{
		return (int)Math.Ceiling((double)(time / Time.fixedDeltaTime));
	}

	// Token: 0x06001114 RID: 4372 RVA: 0x000591C8 File Offset: 0x000575C8
	public static uint ToUtcSeconds(DateTime dateTime)
	{
		DateTime dateTime2 = new DateTime(1970, 1, 1);
		if (dateTime.CompareTo(dateTime2) >= 0 && (dateTime - dateTime2).TotalSeconds > 28800.0)
		{
			return (uint)(dateTime - dateTime2).TotalSeconds - 28800U;
		}
		return 0U;
	}

	// Token: 0x06001115 RID: 4373 RVA: 0x00059228 File Offset: 0x00057628
	public static DateTime ToUtcTime2Local(long secondsFromUtcStart)
	{
		DateTime dateTime = new DateTime(1970, 1, 1);
		return dateTime.AddTicks((secondsFromUtcStart + 28800L) * 10000000L);
	}

	// Token: 0x06001116 RID: 4374 RVA: 0x0005925C File Offset: 0x0005765C
	public static DateTime ULongToDateTime(ulong dtVal)
	{
		ulong[] array = new ulong[6];
		for (int i = 0; i < Utility._DW.Length; i++)
		{
			array[i] = dtVal / Utility._DW[i];
			dtVal -= array[i] * Utility._DW[i];
		}
		array[Utility._DW.Length] = dtVal;
		return new DateTime((int)array[0], (int)array[1], (int)array[2], (int)array[3], (int)array[4], (int)array[5]);
	}

	// Token: 0x06001117 RID: 4375 RVA: 0x000592CA File Offset: 0x000576CA
	public static string UTF8Convert(string str)
	{
		return str;
	}

	// Token: 0x06001118 RID: 4376 RVA: 0x000592CD File Offset: 0x000576CD
	public static string UTF8Convert(byte[] p)
	{
		return StringHelper.UTF8BytesToString(ref p);
	}

	// Token: 0x06001119 RID: 4377 RVA: 0x000592D6 File Offset: 0x000576D6
	public static string UTF8Convert(sbyte[] p, int len)
	{
		return Utility.UTF8Convert(Utility.SByteArrToByte(p));
	}

	// Token: 0x0600111A RID: 4378 RVA: 0x000592E4 File Offset: 0x000576E4
	public static bool WriteFile(string path, byte[] bytes)
	{
		FileStream fileStream = null;
		bool result;
		try
		{
			if (!CFileManager.IsFileExist(path))
			{
				fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
			}
			else
			{
				fileStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
			}
			fileStream.Write(bytes, 0, bytes.Length);
			fileStream.Flush();
			fileStream.Close();
			fileStream.Dispose();
			result = true;
		}
		catch (Exception)
		{
			if (fileStream != null)
			{
				fileStream.Close();
				fileStream.Dispose();
			}
			result = false;
		}
		return result;
	}

	// Token: 0x0600111B RID: 4379 RVA: 0x00059368 File Offset: 0x00057768
	public static string FormatString(string name)
	{
		return name.Replace('\\', '/');
	}

	// Token: 0x0600111C RID: 4380 RVA: 0x00059374 File Offset: 0x00057774
	public static string ProtocolErrorString(uint error)
	{
		ProtoErrorCode protoErrorCode = (ProtoErrorCode)error;
		return protoErrorCode.ToString();
	}

	// Token: 0x0600111D RID: 4381 RVA: 0x00059390 File Offset: 0x00057790
	public static TaskGuideArrow.TaskGuideDir GetPreDirByTargetPos(Vector3 src, Vector3 target)
	{
		TaskGuideArrow.TaskGuideDir result = TaskGuideArrow.TaskGuideDir.TGD_INVALID;
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
		if (clientSystemTown != null)
		{
			Vector3 pathFindingDirection = clientSystemTown.GetPathFindingDirection(src, target);
			if (pathFindingDirection != Vector3.zero)
			{
				if (Mathf.Abs(pathFindingDirection.x) > Mathf.Abs(pathFindingDirection.z))
				{
					if (pathFindingDirection.x < 0f)
					{
						result = TaskGuideArrow.TaskGuideDir.TGD_LEFT;
					}
					else
					{
						result = TaskGuideArrow.TaskGuideDir.TGD_RIGHT;
					}
				}
				else if (pathFindingDirection.z > 0f)
				{
					result = TaskGuideArrow.TaskGuideDir.TGD_TOP;
				}
				else
				{
					result = TaskGuideArrow.TaskGuideDir.TGD_BOTTOM;
				}
			}
		}
		return result;
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x00059428 File Offset: 0x00057828
	public static TaskGuideArrow.TaskGuideDir GetCommandMoveNpcDir(int iNpcID)
	{
		TaskGuideArrow.TaskGuideDir result = TaskGuideArrow.TaskGuideDir.TGD_INVALID;
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
		if (clientSystemTown != null)
		{
			return Utility.GetPreDirByTargetPos(Utility.GetMainRolePosition(), clientSystemTown.GetNpcPostion(iNpcID) - new Vector3(0f, 0f, 1f));
		}
		return result;
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x0005947C File Offset: 0x0005787C
	public static Vector3 GetMainRolePosition()
	{
		Vector3 zero = Vector3.zero;
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
		if (clientSystemTown == null)
		{
			return zero;
		}
		if (clientSystemTown.MainPlayer == null)
		{
			return zero;
		}
		return clientSystemTown.MainPlayer.ActorData.MoveData.Position;
	}

	// Token: 0x06001120 RID: 4384 RVA: 0x000594CC File Offset: 0x000578CC
	public static string GetPathByPkPoints(uint pkPoints, ref int RemainPoints, ref int TotalPoints, ref int pkIndex, ref bool bMaxLv)
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PkLevelTable>();
		int num = -1;
		int num2 = -1;
		int num3 = 0;
		foreach (int num4 in table.Keys)
		{
			PkLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkLevelTable>(num4, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(string.Format(" pk经验表 没有ID为 {0} 的条目", num4), null, string.Empty, false);
				return string.Empty;
			}
			if ((ulong)pkPoints < (ulong)((long)tableItem.MinPkValue))
			{
				num = num4 - 1;
				RemainPoints = tableItem.MinPkValue - (int)pkPoints;
				num2 = tableItem.MinPkValue;
				pkIndex = num3;
				break;
			}
			num3++;
		}
		if (num == -1)
		{
			num = table.Count;
			RemainPoints = 0;
			TotalPoints = 1;
			bMaxLv = true;
			pkIndex = num3;
		}
		else
		{
			bMaxLv = false;
		}
		PkLevelTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PkLevelTable>(num, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		if (!bMaxLv)
		{
			TotalPoints = num2 - tableItem2.MinPkValue;
		}
		return tableItem2.Path;
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x00059614 File Offset: 0x00057A14
	public static string GetNameByPkPoints(uint pkPoints, ref int iLevelType)
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PkLevelTable>();
		int num = -1;
		foreach (int num2 in table.Keys)
		{
			PkLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<PkLevelTable>(num2, string.Empty, string.Empty);
			if (tableItem == null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(string.Format(" pk经验表 没有ID为 {0} 的条目", num2), null, string.Empty, false);
				return string.Empty;
			}
			if ((ulong)pkPoints < (ulong)((long)tableItem.MinPkValue))
			{
				num = num2 - 1;
				break;
			}
		}
		if (num == -1)
		{
			num = table.Count;
		}
		PkLevelTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<PkLevelTable>(num, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		iLevelType = tableItem2.PkLevelType;
		return tableItem2.Name;
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x0005971C File Offset: 0x00057B1C
	public static void GetPKValueNumAndColor(int index, ref Color color1, ref Color color2)
	{
		color1 = new Color32(194, 173, 111, byte.MaxValue);
		color1 = new Color32(194, 173, 111, byte.MaxValue);
		switch (index)
		{
		case 1:
			color1 = new Color32(192, 192, 192, byte.MaxValue);
			color2 = new Color32(192, 192, 192, byte.MaxValue);
			break;
		case 2:
			color1 = new Color32(byte.MaxValue, 197, 27, byte.MaxValue);
			color2 = new Color32(byte.MaxValue, 197, 27, byte.MaxValue);
			break;
		case 3:
			color1 = new Color32(byte.MaxValue, 254, 218, byte.MaxValue);
			color2 = new Color32(byte.MaxValue, 241, 88, byte.MaxValue);
			break;
		case 4:
			color1 = new Color32(247, 233, 13, byte.MaxValue);
			color2 = new Color32(225, 0, 25, byte.MaxValue);
			break;
		}
	}

	// Token: 0x06001123 RID: 4387 RVA: 0x000598AC File Offset: 0x00057CAC
	public static uint GetCurrentTimeUnix()
	{
		return (uint)(DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds;
	}

	// Token: 0x06001124 RID: 4388 RVA: 0x000598E4 File Offset: 0x00057CE4
	public static DateTime GetDateTimeByUnixTime(double d)
	{
		return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(d);
	}

	// Token: 0x06001125 RID: 4389 RVA: 0x00059910 File Offset: 0x00057D10
	public static double GetTimeStamp()
	{
		return (DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds;
	}

	// Token: 0x06001126 RID: 4390 RVA: 0x00059948 File Offset: 0x00057D48
	public static bool CheckCanChangeJob()
	{
		if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
		{
			return false;
		}
		if (!DataManager<MissionManager>.GetInstance().HasAcceptedChangeJobMainMission())
		{
			return false;
		}
		if (DataManager<MissionManager>.GetInstance().HasAcceptedChangeJobMission())
		{
			return false;
		}
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		return tableItem != null && tableItem.JobType < 1;
	}

	// Token: 0x06001127 RID: 4391 RVA: 0x000599C8 File Offset: 0x00057DC8
	public static bool CheckShowChangeJobTaskBtn()
	{
		if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
		{
			return false;
		}
		if (!DataManager<MissionManager>.GetInstance().HasAcceptedChangeJobMission())
		{
			return false;
		}
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		return tableItem != null && tableItem.JobType < 1;
	}

	// Token: 0x06001128 RID: 4392 RVA: 0x00059A34 File Offset: 0x00057E34
	public static bool CheckCanAwake()
	{
		if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
		{
			return false;
		}
		if ((int)DataManager<PlayerBaseData>.GetInstance().Level < ClientSystemTown.Awakelevel)
		{
			return false;
		}
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		return tableItem != null && tableItem.JobType >= 1 && DataManager<PlayerBaseData>.GetInstance().AwakeState <= 0 && !DataManager<MissionManager>.GetInstance().HasAcceptedAwakeMission();
	}

	// Token: 0x06001129 RID: 4393 RVA: 0x00059AC4 File Offset: 0x00057EC4
	public static bool CheckShowAwakeTaskBtn()
	{
		if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
		{
			return false;
		}
		if ((int)DataManager<PlayerBaseData>.GetInstance().Level < ClientSystemTown.Awakelevel)
		{
			return false;
		}
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
		return tableItem != null && tableItem.JobType >= 1 && DataManager<PlayerBaseData>.GetInstance().AwakeState <= 0 && DataManager<MissionManager>.GetInstance().HasAcceptedAwakeMission();
	}

	// Token: 0x0600112A RID: 4394 RVA: 0x00059B54 File Offset: 0x00057F54
	public static void createSprite(string path, ref Image img)
	{
		if (path == null)
		{
			return;
		}
		ETCImageLoader.LoadSprite(ref img, path, true);
	}

	// Token: 0x0600112B RID: 4395 RVA: 0x00059B68 File Offset: 0x00057F68
	public static bool IsDailyMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_DIALY;
	}

	// Token: 0x0600112C RID: 4396 RVA: 0x00059BA0 File Offset: 0x00057FA0
	public static bool IsDailyNormal(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_DIALY && tableItem.SubType == MissionTable.eSubType.Daily_Task;
	}

	// Token: 0x0600112D RID: 4397 RVA: 0x00059BE4 File Offset: 0x00057FE4
	public static bool IsDailyProve(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_DIALY && tableItem.SubType == MissionTable.eSubType.Daily_Prove;
	}

	// Token: 0x0600112E RID: 4398 RVA: 0x00059C28 File Offset: 0x00058028
	public static bool IsChangeJobTask(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB;
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x00059C60 File Offset: 0x00058060
	public static bool IsAwakeTask(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN;
	}

	// Token: 0x06001130 RID: 4400 RVA: 0x00059C98 File Offset: 0x00058098
	public static bool IsMainMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_MAIN;
	}

	// Token: 0x06001131 RID: 4401 RVA: 0x00059CD0 File Offset: 0x000580D0
	public static bool IsBranchMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_BRANCH;
	}

	// Token: 0x06001132 RID: 4402 RVA: 0x00059D08 File Offset: 0x00058108
	public static bool IsAchievementMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT;
	}

	// Token: 0x06001133 RID: 4403 RVA: 0x00059D40 File Offset: 0x00058140
	public static bool IsAccountAchievementMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TASK_ACCOUNT_ACHIEVEMENT;
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x00059D7C File Offset: 0x0005817C
	public static bool IsAdventureTeamAccountWeeklyMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TASK_ADVENTURE_TEAM_ACCOUNT_WEEKLY;
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x00059DB8 File Offset: 0x000581B8
	public static bool IsLegendMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_LEGEND;
	}

	// Token: 0x06001136 RID: 4406 RVA: 0x00059DF4 File Offset: 0x000581F4
	public static bool IsLegendSeriesOverOnce(int iTableId, int finishedMissionId)
	{
		LegendMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LegendMainTable>(iTableId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return false;
		}
		for (int i = 0; i < tableItem.missionIds.Count; i++)
		{
			int num = tableItem.missionIds[i];
			MissionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(num, string.Empty, string.Empty);
			if (tableItem2 != null && tableItem2.MissionOnOff == 1)
			{
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)num);
				if (num == finishedMissionId)
				{
					if (mission == null || mission.submitCount != 1)
					{
						return false;
					}
				}
				else if (mission == null || mission.submitCount < 1)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x00059EBC File Offset: 0x000582BC
	public static bool IsLegendSeriesOver(int iTableID)
	{
		LegendMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<LegendMainTable>(iTableID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return false;
		}
		for (int i = 0; i < tableItem.missionIds.Count; i++)
		{
			MissionTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(tableItem.missionIds[i], string.Empty, string.Empty);
			if (tableItem2 != null && tableItem2.MissionOnOff == 1)
			{
				MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)tableItem.missionIds[i]);
				if (mission == null || mission.status != 5)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06001138 RID: 4408 RVA: 0x00059F67 File Offset: 0x00058367
	public static int GetLegendMainStatus(LegendMainTable mainItem)
	{
		if (Utility.IsLegendSeriesOver(mainItem.ID))
		{
			return 2;
		}
		if ((int)DataManager<PlayerBaseData>.GetInstance().Level < mainItem.UnLockLevel)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x00059F94 File Offset: 0x00058394
	public static bool IsAchievementMissionNormal(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && tableItem.SubType == MissionTable.eSubType.Daily_Null;
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x00059FD8 File Offset: 0x000583D8
	public static bool IsChangeJobMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB;
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x0005A010 File Offset: 0x00058410
	public static bool IsAwakeMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN;
	}

	// Token: 0x0600113C RID: 4412 RVA: 0x0005A048 File Offset: 0x00058448
	public static bool IsNormalMission(uint iMissionID)
	{
		MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
		return tableItem != null && tableItem.TaskType != MissionTable.eTaskType.TT_ACHIEVEMENT && tableItem.TaskType != MissionTable.eTaskType.TT_DIALY;
	}

	// Token: 0x0600113D RID: 4413 RVA: 0x0005A08B File Offset: 0x0005848B
	public static int ceil(float fValue)
	{
		return (int)(fValue + 0.5f);
	}

	// Token: 0x0600113E RID: 4414 RVA: 0x0005A098 File Offset: 0x00058498
	public static string GetEnumDescription<T>(T enumValue)
	{
		string text = enumValue.ToString();
		FieldInfo field = enumValue.GetType().GetField(text);
		if (field != null)
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				DescriptionAttribute descriptionAttribute = (DescriptionAttribute)customAttributes[0];
				text = descriptionAttribute.Description;
			}
			customAttributes = field.GetCustomAttributes(typeof(UIPropertyAttribute), false);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				UIPropertyAttribute uipropertyAttribute = (UIPropertyAttribute)customAttributes[0];
				text = uipropertyAttribute.name + uipropertyAttribute.formatString;
			}
		}
		return text;
	}

	// Token: 0x0600113F RID: 4415 RVA: 0x0005A140 File Offset: 0x00058540
	public static string GetEnumCommonValue<T>(T enumValue, int iIndex = 0)
	{
		FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
		if (field != null)
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(EnumCommonAttribute), false);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				EnumCommonAttribute enumCommonAttribute = customAttributes[0] as EnumCommonAttribute;
				return enumCommonAttribute.GetValueByIndex(iIndex);
			}
		}
		return string.Empty;
	}

	// Token: 0x06001140 RID: 4416 RVA: 0x0005A1AC File Offset: 0x000585AC
	public static Attribute GetEnumAttribute<T, Attribute>(T enumValue)
	{
		string name = enumValue.ToString();
		FieldInfo field = enumValue.GetType().GetField(name);
		if (field != null)
		{
			object[] customAttributes = field.GetCustomAttributes(typeof(Attribute), false);
			if (customAttributes != null && customAttributes.Length > 0)
			{
				return (Attribute)((object)customAttributes[0]);
			}
		}
		return default(Attribute);
	}

	// Token: 0x06001141 RID: 4417 RVA: 0x0005A214 File Offset: 0x00058614
	public static List<int> GetAwakeTaskList()
	{
		List<int> list = new List<int>();
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MissionTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			MissionTable missionTable = keyValuePair.Value as MissionTable;
			if (missionTable.TaskType == MissionTable.eTaskType.TT_AWAKEN)
			{
				if (missionTable.JobID == DataManager<PlayerBaseData>.GetInstance().JobTableID || missionTable.JobID == 0)
				{
					list.Add(missionTable.ID);
				}
			}
		}
		return list;
	}

	// Token: 0x06001142 RID: 4418 RVA: 0x0005A2A4 File Offset: 0x000586A4
	public static List<int> GetChangeJobTaskList()
	{
		List<int> list = new List<int>();
		List<MissionManager.SingleMissionInfo> diffTask = DataManager<MissionManager>.GetInstance().GetDiffTask(MissionTable.eTaskType.TT_CHANGEJOB);
		if (diffTask == null || diffTask.Count < 1)
		{
			return list;
		}
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MissionTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			MissionTable missionTable = keyValuePair.Value as MissionTable;
			if (missionTable.TaskType == MissionTable.eTaskType.TT_CHANGEJOB)
			{
				for (int i = 0; i < diffTask.Count; i++)
				{
					if (diffTask[i].missionItem.MissionParam == missionTable.MissionParam && diffTask[i].status > 0)
					{
						list.Add(missionTable.ID);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x06001143 RID: 4419 RVA: 0x0005A380 File Offset: 0x00058780
	public static bool IsUnLockFunc(int iID)
	{
		bool result = false;
		for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().UnlockFuncList.Count; i++)
		{
			if (DataManager<PlayerBaseData>.GetInstance().UnlockFuncList[i] == iID)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06001144 RID: 4420 RVA: 0x0005A3D0 File Offset: 0x000587D0
	public static bool IsUnLockArea(int iAreaID)
	{
		bool result = false;
		for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().UnlockAreaList.Count; i++)
		{
			if (DataManager<PlayerBaseData>.GetInstance().UnlockAreaList[i] == iAreaID)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06001145 RID: 4421 RVA: 0x0005A420 File Offset: 0x00058820
	public static int GetMallRealPrice(MallItemInfo iteminfo)
	{
		int result = (int)iteminfo.price;
		if (iteminfo.discountprice > 0U)
		{
			result = (int)iteminfo.discountprice;
		}
		return result;
	}

	// Token: 0x06001146 RID: 4422 RVA: 0x0005A448 File Offset: 0x00058848
	public static int GetMallRealPrice(MallItemDetailInfo iteminfo)
	{
		int result = (int)iteminfo.price;
		if (iteminfo.discountPrice > 0U)
		{
			result = (int)iteminfo.discountPrice;
		}
		return result;
	}

	// Token: 0x06001147 RID: 4423 RVA: 0x0005A474 File Offset: 0x00058874
	public static KeyValuePair<int, float> GetFirstValidVipLevelPrivilegeData(VipPrivilegeTable.eType PrivilegeType)
	{
		VipPrivilegeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>((int)PrivilegeType, string.Empty, string.Empty);
		SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
		KeyValuePair<int, float> result = new KeyValuePair<int, float>(-1, 0f);
		if (tableItem != null && tableItem2 != null)
		{
			for (int i = 1; i <= tableItem2.Value; i++)
			{
				PropertyInfo property = tableItem.GetType().GetProperty(string.Format("VIP{0}", i), BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					int num = (int)property.GetValue(tableItem, null);
					if (num > 0)
					{
						if (tableItem.DataType == VipPrivilegeTable.eDataType.FLOAT)
						{
							result = new KeyValuePair<int, float>(i, (float)num / 1000f);
						}
						else
						{
							result = new KeyValuePair<int, float>(i, (float)num);
						}
						break;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06001148 RID: 4424 RVA: 0x0005A550 File Offset: 0x00058950
	public static float GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType PrivilegeType)
	{
		VipPrivilegeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>((int)PrivilegeType, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 0f;
		}
		SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
		if (DataManager<PlayerBaseData>.GetInstance().VipLevel > tableItem2.Value)
		{
			return 0f;
		}
		PropertyInfo property = tableItem.GetType().GetProperty(string.Format("VIP{0}", DataManager<PlayerBaseData>.GetInstance().VipLevel), BindingFlags.Instance | BindingFlags.Public);
		if (property == null)
		{
			return 0f;
		}
		int num = (int)property.GetValue(tableItem, null);
		if (num <= 0)
		{
			return 0f;
		}
		if (tableItem.DataType == VipPrivilegeTable.eDataType.FLOAT)
		{
			return (float)num / 1000f;
		}
		return (float)num;
	}

	// Token: 0x06001149 RID: 4425 RVA: 0x0005A618 File Offset: 0x00058A18
	public static float GetCurVipLevelPrivilegeData(int iID)
	{
		VipPrivilegeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipPrivilegeTable>(iID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 0f;
		}
		SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
		if (DataManager<PlayerBaseData>.GetInstance().VipLevel > tableItem2.Value)
		{
			return 0f;
		}
		PropertyInfo property = tableItem.GetType().GetProperty(string.Format("VIP{0}", DataManager<PlayerBaseData>.GetInstance().VipLevel), BindingFlags.Instance | BindingFlags.Public);
		if (property == null)
		{
			return 0f;
		}
		int num = (int)property.GetValue(tableItem, null);
		if (num <= 0)
		{
			return 0f;
		}
		if (tableItem.DataType == VipPrivilegeTable.eDataType.FLOAT)
		{
			return (float)num / 1000f;
		}
		return (float)num;
	}

	// Token: 0x0600114A RID: 4426 RVA: 0x0005A6E0 File Offset: 0x00058AE0
	public static List<string> GetPrivilegeDescListByVipLevel(int VipLevel)
	{
		List<string> list = new List<string>();
		SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
		if (VipLevel > tableItem.Value)
		{
			return list;
		}
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<VipPrivilegeTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			VipPrivilegeTable vipPrivilegeTable = keyValuePair.Value as VipPrivilegeTable;
			PropertyInfo property = vipPrivilegeTable.GetType().GetProperty(string.Format("VIP{0}", VipLevel), BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				int num = (int)property.GetValue(vipPrivilegeTable, null);
				if (num > 0)
				{
					if (VipLevel > 0)
					{
						if (vipPrivilegeTable.Type == VipPrivilegeTable.eType.PK_MONEY_LIMIT)
						{
							SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(2, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								num += tableItem2.Value;
							}
						}
						else if (vipPrivilegeTable.Type == VipPrivilegeTable.eType.MYSTERIOUS_SHOP_REFRESH_NUM)
						{
							SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(4, string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								num += tableItem3.Value;
							}
						}
					}
					if (vipPrivilegeTable.DataType == VipPrivilegeTable.eDataType.FLOAT)
					{
						list.Add(string.Format(vipPrivilegeTable.Description, (float)num / 10f) + "%");
					}
					else
					{
						list.Add(string.Format(vipPrivilegeTable.Description, num));
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0600114B RID: 4427 RVA: 0x0005A86C File Offset: 0x00058C6C
	public static ChangeJobState GetChangeJobState()
	{
		return ChangeJobState.JobState_Null;
	}

	// Token: 0x0600114C RID: 4428 RVA: 0x0005A870 File Offset: 0x00058C70
	public static bool IsFunctionOpen(string ButtonPath)
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FunctionUnLock>();
		Dictionary<int, object>.Enumerator enumerator = table.GetEnumerator();
		bool result = false;
		bool flag = false;
		while (enumerator.MoveNext())
		{
			KeyValuePair<int, object> keyValuePair = enumerator.Current;
			FunctionUnLock functionUnLock = keyValuePair.Value as FunctionUnLock;
			if (!(functionUnLock.TargetBtnPos == string.Empty) && !(functionUnLock.TargetBtnPos == "-"))
			{
				if (!(functionUnLock.TargetBtnPos != ButtonPath))
				{
					flag = true;
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= functionUnLock.FinishLevel)
					{
						result = true;
					}
					break;
				}
			}
		}
		if (!flag)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600114D RID: 4429 RVA: 0x0005A92C File Offset: 0x00058D2C
	public static string GetStringByFloat(float fdata)
	{
		string result = string.Empty;
		int num = (int)fdata;
		int num2 = (int)(fdata * 10f);
		float num3 = fdata * 100f;
		if ((double)Math.Abs(fdata - (float)num) < 0.01)
		{
			result = fdata.ToString("f0");
		}
		else if (Math.Abs(num3 - (float)(num2 * 10)) <= 10f)
		{
			result = fdata.ToString("f1");
		}
		else if (num3 > (float)(num * 100))
		{
			result = fdata.ToString("f2");
		}
		return result;
	}

	// Token: 0x0600114E RID: 4430 RVA: 0x0005A9C0 File Offset: 0x00058DC0
	public static bool IsFunctionCanUnlock(FunctionUnLock.eFuncType funcType)
	{
		FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)funcType, string.Empty, string.Empty);
		return tableItem == null || (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.FinishLevel;
	}

	// Token: 0x0600114F RID: 4431 RVA: 0x0005AA00 File Offset: 0x00058E00
	public static bool IsFunctionCanUnlock(FunctionUnLock.eFuncType funcType, int iCurLv)
	{
		FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)funcType, string.Empty, string.Empty);
		return tableItem == null || iCurLv >= tableItem.FinishLevel;
	}

	// Token: 0x06001150 RID: 4432 RVA: 0x0005AA38 File Offset: 0x00058E38
	public static int GetFunctionUnlockLevel(FunctionUnLock.eFuncType funcType)
	{
		FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)funcType, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 1;
		}
		return tableItem.FinishLevel;
	}

	// Token: 0x06001151 RID: 4433 RVA: 0x0005AA6C File Offset: 0x00058E6C
	public static Utility.StrengthOperateResult CheckGrowthItem(ItemData data, bool bUseProtected = false)
	{
		Utility.StrengthOperateResult result = Utility.StrengthOperateResult.SOR_HAS_NO_ITEM;
		if (data == null)
		{
			return result;
		}
		List<ItemSimpleData> growthCosts = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthCosts(data);
		if (growthCosts == null || growthCosts.Count <= 0)
		{
		}
		result = Utility.StrengthOperateResult.SOR_OK;
		for (int i = 0; i < growthCosts.Count; i++)
		{
			ItemSimpleData itemSimpleData = growthCosts[i];
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemSimpleData.ItemID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(itemSimpleData.ItemID, true);
				int count = itemSimpleData.Count;
				if (tableItem.SubType == ItemTable.eSubType.BindGOLD)
				{
					if (count > ownedItemCount)
					{
						result = Utility.StrengthOperateResult.SOR_GOLD;
						break;
					}
				}
				else if (tableItem.ID == 300000105)
				{
					if (count > ownedItemCount)
					{
						result = Utility.StrengthOperateResult.SOR_COLOR;
						break;
					}
				}
				else if (tableItem.SubType == ItemTable.eSubType.ST_ZENGFU_MATERIAL && count > ownedItemCount)
				{
					result = Utility.StrengthOperateResult.SOR_Paradoxicalcrystal;
					break;
				}
			}
		}
		int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000207, true);
		if (bUseProtected && ownedItemCount2 <= 0 && data.StrengthenLevel >= 10)
		{
			result = Utility.StrengthOperateResult.SOR_HAS_NO_PROTECTED;
		}
		return result;
	}

	// Token: 0x06001152 RID: 4434 RVA: 0x0005ABA4 File Offset: 0x00058FA4
	public static Utility.StrengthOperateResult CheckStrengthenItem(ItemData data, bool bUseProtected = false)
	{
		Utility.StrengthOperateResult result = Utility.StrengthOperateResult.SOR_HAS_NO_ITEM;
		if (data == null)
		{
			return result;
		}
		int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000106, true);
		int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(300000105, true);
		int ownedItemCount3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD), true);
		int ownedItemCount4 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(200000310, true);
		StrengthenCost strengthenCost = default(StrengthenCost);
		if (!DataManager<StrengthenDataManager>.GetInstance().GetCost(data.StrengthenLevel, data.LevelLimit, data.Quality, ref strengthenCost))
		{
		}
		if (data.SubType == 1)
		{
			float num = 1f;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(21, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = (float)tableItem.Value / 10f;
			}
			strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num);
			strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num);
			strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num);
		}
		else if (data.SubType >= 2 && data.SubType <= 6)
		{
			float num2 = 1f;
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(22, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				num2 = (float)tableItem2.Value / 10f;
			}
			strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num2);
			strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num2);
			strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num2);
		}
		else if (data.SubType >= 7 && data.SubType <= 9)
		{
			float num3 = 1f;
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(23, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				num3 = (float)tableItem3.Value / 10f;
			}
			strengthenCost.ColorCost = Utility.ceil((float)strengthenCost.ColorCost * num3);
			strengthenCost.UnColorCost = Utility.ceil((float)strengthenCost.UnColorCost * num3);
			strengthenCost.GoldCost = Utility.ceil((float)strengthenCost.GoldCost * num3);
		}
		result = Utility.StrengthOperateResult.SOR_OK;
		if (strengthenCost.UnColorCost > ownedItemCount)
		{
			result = Utility.StrengthOperateResult.SOR_UNCOLOR;
		}
		else if (strengthenCost.ColorCost > ownedItemCount2)
		{
			result = Utility.StrengthOperateResult.SOR_COLOR;
		}
		else if (strengthenCost.GoldCost > ownedItemCount3)
		{
			result = Utility.StrengthOperateResult.SOR_GOLD;
		}
		else if (bUseProtected && ownedItemCount4 <= 0 && data.StrengthenLevel >= 10)
		{
			result = Utility.StrengthOperateResult.SOR_HAS_NO_PROTECTED;
		}
		return result;
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x0005AE48 File Offset: 0x00059248
	public static void OnPopupStrengthenResultMsg(Utility.StrengthOperateResult eStrengthOperateResult)
	{
		if (eStrengthOperateResult != Utility.StrengthOperateResult.SOR_OK)
		{
			switch (eStrengthOperateResult)
			{
			case Utility.StrengthOperateResult.SOR_HAS_NO_ITEM:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_item_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_UNCOLOR:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_uncolor_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_COLOR:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_color_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_GOLD:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_gold_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_COST_ITEM_NOT_EXIST:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_cost_tablie_item_not_enough"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_HAS_NO_PROTECTED:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("strengthen_has_not_protected"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_Paradoxicalcrystal:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("growth_paradoxicalcrystal"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			case Utility.StrengthOperateResult.SOR_Has_No_GrowthProtectd:
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("growth_has_not_protected"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				break;
			}
			return;
		}
	}

	// Token: 0x06001154 RID: 4436 RVA: 0x0005AF34 File Offset: 0x00059334
	public static string GetValueByTableName(float fValue, string propname)
	{
		if (propname == "maxHp" || propname == "maxMp" || propname == "defence" || propname == "magicDefence")
		{
			return Utility.GetStringByFloat(fValue);
		}
		if (propname == "attackSpeed" || propname == "dex" || propname == "spellSpeed" || propname == "dodge")
		{
			return Utility.GetStringByFloat(fValue / 10f) + "%";
		}
		return Utility.GetStringByFloat(fValue / 1000f);
	}

	// Token: 0x06001155 RID: 4437 RVA: 0x0005AFEC File Offset: 0x000593EC
	public static void SwitchToPkWaitingRoom(PkRoomType ePkRoomType = PkRoomType.TraditionPk)
	{
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
		if (clientSystemTown == null)
		{
			return;
		}
		CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
		{
			ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
			clientSystemTownFrame.SetForbidFadeIn(true);
		}
		int targetSceneID = tableItem.TraditionSceneID;
		if (ePkRoomType == PkRoomType.BudoPk)
		{
			targetSceneID = tableItem.BudoSceneID;
		}
		MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
		{
			currSceneID = clientSystemTown.CurrentSceneID,
			currDoorID = 0,
			targetSceneID = targetSceneID,
			targetDoorID = 0
		}, false));
	}

	// Token: 0x06001156 RID: 4438 RVA: 0x0005B0B8 File Offset: 0x000594B8
	public static void SwitchToChiJiRoom()
	{
		ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
		if (clientSystemGameBattle != null)
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemGameBattle._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemGameBattle.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 10100,
				targetDoorID = 0
			}, false));
		}
	}

	// Token: 0x06001157 RID: 4439 RVA: 0x0005B11C File Offset: 0x0005951C
	public static void SwitchToChijiWaittingRoom()
	{
		if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
		{
			return;
		}
		Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemGameBattle>(null, null, false);
	}

	// Token: 0x06001158 RID: 4440 RVA: 0x0005B150 File Offset: 0x00059550
	public static Rect GetScreenRect()
	{
		Rect result;
		result..ctor((float)(-(float)Screen.width / 2), (float)(-(float)Screen.height / 2), (float)Screen.width, (float)Screen.height);
		GameObject gameObject = GameObject.Find("UIRoot/UI2DRoot");
		if (gameObject != null)
		{
			CanvasScaler component = gameObject.GetComponent<CanvasScaler>();
			if (component != null)
			{
				float num = (component.matchWidthOrHeight != 1f) ? (component.referenceResolution.x / (float)Screen.width) : (component.referenceResolution.y / (float)Screen.height);
				result..ctor(result.x * num, result.y * num, result.width * num, result.height * num);
			}
		}
		return result;
	}

	// Token: 0x06001159 RID: 4441 RVA: 0x0005B21C File Offset: 0x0005961C
	public static void AddUICanvasCom(GameObject obj, int sortingOrder = 1, int layer = 5, bool r = false)
	{
		if (obj == null)
		{
			return;
		}
		obj.layer = layer;
		Canvas canvas = obj.GetComponent<Canvas>();
		if (null == canvas)
		{
			canvas = obj.AddComponent<Canvas>();
			canvas.overrideSorting = true;
			canvas.sortingOrder = sortingOrder;
		}
		else
		{
			canvas.overrideSorting = true;
			canvas.sortingOrder = sortingOrder;
		}
		if (r)
		{
			for (int i = 0; i < obj.transform.childCount; i++)
			{
				Utility.AddUICanvasCom(obj.transform.GetChild(i).gameObject, sortingOrder, layer, r);
			}
		}
	}

	// Token: 0x0600115A RID: 4442 RVA: 0x0005B2B4 File Offset: 0x000596B4
	public static bool SetUIArea(RectTransform target, Rect area, Transform canvas)
	{
		Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(canvas, target);
		Vector2 vector = default(Vector2);
		if (bounds.center.x - bounds.extents.x < area.x)
		{
			vector.x += Mathf.Abs(bounds.center.x - bounds.extents.x - area.x);
		}
		else if (bounds.center.x + bounds.extents.x > area.width / 2f)
		{
			vector.x -= Mathf.Abs(bounds.center.x + bounds.extents.x - area.width / 2f);
		}
		if (bounds.center.y - bounds.extents.y < area.y)
		{
			vector.y += Mathf.Abs(bounds.center.y - bounds.extents.y - area.y);
		}
		else if (bounds.center.y + bounds.extents.y > area.height / 2f)
		{
			vector.y -= Mathf.Abs(bounds.center.y + bounds.extents.y - area.height / 2f);
		}
		target.anchoredPosition += vector;
		return vector != default(Vector2);
	}

	// Token: 0x0600115B RID: 4443 RVA: 0x0005B4BC File Offset: 0x000598BC
	public static ulong GetRoleTotalExp()
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ExpTable>();
		ulong num = 0UL;
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			ExpTable expTable = keyValuePair.Value as ExpTable;
			if (expTable.ID >= (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				break;
			}
			num += (ulong)((long)expTable.TotalExp);
		}
		num += DataManager<PlayerBaseData>.GetInstance().CurExp;
		return num;
	}

	// Token: 0x0600115C RID: 4444 RVA: 0x0005B564 File Offset: 0x00059964
	public static void SetInitTownSystemState()
	{
		if (!DataManager<PlayerBaseData>.GetInstance().bInitializeTownSystem)
		{
			DataManager<PlayerBaseData>.GetInstance().bInitializeTownSystem = true;
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.InitializeTownSystem, null, null, null, null);
		}
	}

	// Token: 0x0600115D RID: 4445 RVA: 0x0005B594 File Offset: 0x00059994
	public static bool IsShowDailyProveRedPoint()
	{
		List<MissionManager.SingleMissionInfo> list = DataManager<MissionManager>.GetInstance().taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
		for (int i = 0; i < list.Count; i++)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)list[i].taskID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_DIALY && tableItem.SubType == MissionTable.eSubType.Daily_Prove)
			{
				if (list[i].status >= 2 && list[i].status < 5)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600115E RID: 4446 RVA: 0x0005B638 File Offset: 0x00059A38
	public static int GetItemNumByTableID(int iItemID)
	{
		int num = 0;
		Dictionary<ulong, ItemData> allPackageItems = DataManager<ItemDataManager>.GetInstance().GetAllPackageItems();
		if (allPackageItems == null)
		{
			return num;
		}
		foreach (ulong id in allPackageItems.Keys)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
			if (item != null)
			{
				if (item.TableID == iItemID)
				{
					num += item.Count;
				}
			}
		}
		return num;
	}

	// Token: 0x0600115F RID: 4447 RVA: 0x0005B6D8 File Offset: 0x00059AD8
	public static void SwitchSelectTextColor(Text text, Color clo, bool bIsSelect = true)
	{
		if (bIsSelect)
		{
			text.color = clo;
			Outline component = text.GetComponent<Outline>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		else
		{
			text.color = clo;
			Outline component2 = text.GetComponent<Outline>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
		}
	}

	// Token: 0x06001160 RID: 4448 RVA: 0x0005B734 File Offset: 0x00059B34
	private static QuickBuyTable _getQuickBuyItemTable(ItemTable.eSubType type)
	{
		int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(type);
		QuickBuyTable tableItem = Singleton<TableManager>.instance.GetTableItem<QuickBuyTable>(moneyIDByType, string.Empty, string.Empty);
		if (tableItem == null)
		{
			Logger.LogErrorFormat(" {0} 不是货币类型", new object[]
			{
				type
			});
		}
		return tableItem;
	}

	// Token: 0x06001161 RID: 4449 RVA: 0x0005B784 File Offset: 0x00059B84
	public static int GetQuickBuyCostCount(ItemTable.eSubType type)
	{
		QuickBuyTable quickBuyTable = Utility._getQuickBuyItemTable(type);
		if (quickBuyTable != null)
		{
			return quickBuyTable.CostNum;
		}
		return -1;
	}

	// Token: 0x06001162 RID: 4450 RVA: 0x0005B7A8 File Offset: 0x00059BA8
	public static int GetQuickBuyCostItemID(ItemTable.eSubType type)
	{
		QuickBuyTable quickBuyTable = Utility._getQuickBuyItemTable(type);
		if (quickBuyTable != null)
		{
			return quickBuyTable.CostItemID;
		}
		return -1;
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x0005B7CC File Offset: 0x00059BCC
	public static bool CanQuickBuyItem(ItemTable.eSubType type)
	{
		QuickBuyTable quickBuyTable = Utility._getQuickBuyItemTable(type);
		if (quickBuyTable == null)
		{
			return false;
		}
		ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(quickBuyTable.CostItemID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return false;
		}
		int costNum = quickBuyTable.CostNum;
		ItemTable.eSubType subType = tableItem.SubType;
		if (subType != ItemTable.eSubType.GOLD)
		{
			if (subType != ItemTable.eSubType.POINT)
			{
				if (subType == ItemTable.eSubType.BindGOLD)
				{
					goto IL_72;
				}
				if (subType != ItemTable.eSubType.BindPOINT)
				{
					Logger.LogErrorFormat("货币类型 {0} 未实现快速购买工具函数", new object[]
					{
						type
					});
					return false;
				}
			}
			return DataManager<PlayerBaseData>.GetInstance().CanUseTicket((ulong)((long)costNum));
		}
		IL_72:
		return DataManager<PlayerBaseData>.GetInstance().CanUseGold((ulong)((long)costNum));
	}

	// Token: 0x06001164 RID: 4452 RVA: 0x0005B878 File Offset: 0x00059C78
	public static void IterCoroutineImm(IEnumerator iter)
	{
		if (iter != null)
		{
			while (iter.MoveNext())
			{
				object obj = iter.Current;
				IEnumerator enumerator = obj as IEnumerator;
				if (enumerator != null)
				{
					Utility.IterCoroutineImm(enumerator);
				}
			}
		}
	}

	// Token: 0x06001165 RID: 4453 RVA: 0x0005B8B8 File Offset: 0x00059CB8
	public static string GetMissionIcon(MissionTable.eTaskType eTaskType)
	{
		if (eTaskType == MissionTable.eTaskType.TT_MAIN)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Zhuxian";
		}
		if (eTaskType == MissionTable.eTaskType.TT_BRANCH)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Zhixian";
		}
		if (eTaskType == MissionTable.eTaskType.TT_ACHIEVEMENT)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Renwu";
		}
		if (eTaskType == MissionTable.eTaskType.TT_DIALY)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Renwu";
		}
		if (eTaskType == MissionTable.eTaskType.TT_CYCLE)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Xunhuan";
		}
		if (eTaskType == MissionTable.eTaskType.TT_CHANGEJOB)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Zhuanzhi";
		}
		if (eTaskType == MissionTable.eTaskType.TT_TITLE)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Chenghao";
		}
		if (eTaskType == MissionTable.eTaskType.TT_AWAKEN)
		{
			return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Juexing";
		}
		return "UI/Image/Packed/p_UI_Task.png:UI_Renwu_Tubiao_Zhuxian";
	}

	// Token: 0x06001166 RID: 4454 RVA: 0x0005B933 File Offset: 0x00059D33
	public static bool IsPlayerLevelFull(int iLevel)
	{
		return Utility.GetPlayerMaxLevel() <= iLevel;
	}

	// Token: 0x06001167 RID: 4455 RVA: 0x0005B940 File Offset: 0x00059D40
	public static MethodInfo GetMethodInfoFromString(string methodStr)
	{
		string[] array = methodStr.Split(new char[]
		{
			'.'
		});
		if (array != null && array.Length >= 2)
		{
			string name = array[array.Length - 1];
			string text = string.Empty;
			for (int i = 0; i < array.Length - 1; i++)
			{
				if (i != 0)
				{
					text += ".";
				}
				text += array[i];
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType(text);
			return type.GetMethod(name);
		}
		return null;
	}

	// Token: 0x06001168 RID: 4456 RVA: 0x0005B9D0 File Offset: 0x00059DD0
	public static string GetEquipProCeilValueDesc(EEquipProp eEEquipProp, int attrValue)
	{
		string result = string.Empty;
		if ((eEEquipProp >= EEquipProp.Strenth && eEEquipProp <= EEquipProp.Stamina) || eEEquipProp == EEquipProp.Independence)
		{
			result = string.Format("+{0}", (float)attrValue / 1000f);
		}
		else if (eEEquipProp == EEquipProp.AbormalResist || (eEEquipProp >= EEquipProp.LightAttack && eEEquipProp <= EEquipProp.DarkDefence))
		{
			result = string.Format("+{0}", attrValue);
		}
		else if (eEEquipProp >= EEquipProp.AttackSpeedRate && eEEquipProp <= EEquipProp.MagicCritRate)
		{
			float num = (float)attrValue * 1f / 10f;
			string arg = string.Empty;
			if (num >= 0f)
			{
				arg = TR.Value("tip_rate_2_level_format_up", Utility.ConvertItemDataRateValue2IntLevel(num), num);
			}
			else
			{
				arg = TR.Value("tip_rate_2_level_format_down", Utility.ConvertItemDataRateValue2IntLevel(num), num);
			}
			result = string.Format("+{0}", arg);
		}
		else
		{
			result = string.Format("+{0}", attrValue);
		}
		return result;
	}

	// Token: 0x06001169 RID: 4457 RVA: 0x0005BAD4 File Offset: 0x00059ED4
	public static string GetEEquipProDesc(EEquipProp eEEquipProp, int attrValue, string inner = "")
	{
		PropAttribute enumAttribute = Utility.GetEnumAttribute<EEquipProp, PropAttribute>(eEEquipProp);
		string text = enumAttribute.desc;
		if ((eEEquipProp >= EEquipProp.Strenth && eEEquipProp <= EEquipProp.Stamina) || eEEquipProp == EEquipProp.Independence)
		{
			text = string.Format("{0}{2}+{1}", text, (float)attrValue / 1000f, inner);
		}
		else if (eEEquipProp == EEquipProp.Elements)
		{
			text = string.Format("{0}{2}:{1}", text, Utility.GetEnumDescription<MagicElementType>((MagicElementType)attrValue), inner);
		}
		else if (eEEquipProp == EEquipProp.AbormalResist || (eEEquipProp >= EEquipProp.LightAttack && eEEquipProp <= EEquipProp.DarkDefence))
		{
			text = string.Format("{0}{2}+{1}", text, attrValue, inner);
		}
		else if (eEEquipProp >= EEquipProp.AttackSpeedRate && eEEquipProp <= EEquipProp.MagicCritRate)
		{
			float num = (float)attrValue * 1f / 10f;
			string arg = string.Empty;
			if (num >= 0f)
			{
				arg = TR.Value("tip_rate_2_level_format_up", Utility.ConvertItemDataRateValue2IntLevel(num), num);
			}
			else
			{
				arg = TR.Value("tip_rate_2_level_format_down", Utility.ConvertItemDataRateValue2IntLevel(num), num);
			}
			text = string.Format("{0}{1}+{2}", text, inner, arg);
		}
		else
		{
			text = string.Format("{0}{2}+{1}", text, attrValue, inner);
		}
		return text;
	}

	// Token: 0x0600116A RID: 4458 RVA: 0x0005BC08 File Offset: 0x0005A008
	public static void OnItemClicked(GameObject obj, ItemData item)
	{
		if (item != null)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
		}
	}

	// Token: 0x0600116B RID: 4459 RVA: 0x0005BC20 File Offset: 0x0005A020
	public static int GetSystemValueFromTable(SystemValueTable.eType eType)
	{
		SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>((int)eType, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.Value;
		}
		return 0;
	}

	// Token: 0x0600116C RID: 4460 RVA: 0x0005BC54 File Offset: 0x0005A054
	public static int GetSystemValueFromTable(SystemValueTable.eType2 eType2)
	{
		SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>((int)eType2, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.Value;
		}
		return 0;
	}

	// Token: 0x0600116D RID: 4461 RVA: 0x0005BC88 File Offset: 0x0005A088
	public static int GetSystemValueFromTable(SystemValueTable.eType3 eType3, int defaultValue = 0)
	{
		SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>((int)eType3, string.Empty, string.Empty);
		if (tableItem != null)
		{
			return tableItem.Value;
		}
		return defaultValue;
	}

	// Token: 0x0600116E RID: 4462 RVA: 0x0005BCBC File Offset: 0x0005A0BC
	public static List<AwardItemData> ParseAwardItemDatas(string awardString, string tokenPrimary = "|", string tokenSecondary = "_")
	{
		if (string.IsNullOrEmpty(awardString))
		{
			return null;
		}
		List<AwardItemData> list = new List<AwardItemData>();
		if (list == null)
		{
			return null;
		}
		string[] array = awardString.Split(tokenPrimary.ToCharArray());
		if (array == null)
		{
			return list;
		}
		foreach (string text in array)
		{
			if (!string.IsNullOrEmpty(text))
			{
				string[] array2 = text.Split(tokenSecondary.ToCharArray());
				if (array2 != null)
				{
					if (array2.Length >= 2)
					{
						int id = int.Parse(array2[0]);
						int num = int.Parse(array2[1]);
						list.Add(new AwardItemData
						{
							ID = id,
							Num = num
						});
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x0005BD80 File Offset: 0x0005A180
	public static void PathfindingYiJieMap()
	{
		string link = "<type=mapid value=3101000>";
		DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(link, null, false);
		if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
		}
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x0005BDBC File Offset: 0x0005A1BC
	public static string GetHexColor(Color color)
	{
		return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>", new object[]
		{
			(int)(255f * color.r),
			(int)(255f * color.g),
			(int)(255f * color.b),
			(int)(255f * color.a)
		});
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x0005BE34 File Offset: 0x0005A234
	public static void UseOneKeySuitWear(int suitId, int strength, int type = 0, int attr = 0)
	{
		OneKeyWearTable tableItem = Singleton<TableManager>.instance.GetTableItem<OneKeyWearTable>(suitId, string.Empty, string.Empty);
		if (tableItem != null && DataManager<ChatManager>.GetInstance() != null)
		{
			for (int i = 0; i < tableItem.EquipList.Count; i++)
			{
				int valueFromUnionCell = TableManager.GetValueFromUnionCell(tableItem.EquipList[i], 1, true);
				if (type > 0)
				{
					DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_WORLD, string.Format("!!addee id={0} num={1} ql={2} str={3} et={4} ent={5}", new object[]
					{
						valueFromUnionCell,
						1,
						"100",
						strength,
						type,
						attr
					}), 0UL, 0);
				}
				else
				{
					DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_WORLD, string.Format("!!additem id={0} num={1} str={2} ql={3}", new object[]
					{
						valueFromUnionCell,
						1,
						strength,
						"100"
					}), 0UL, 0);
				}
			}
			for (int j = 0; j < tableItem.FashionList.Count; j++)
			{
				int valueFromUnionCell2 = TableManager.GetValueFromUnionCell(tableItem.FashionList[j], 1, true);
				DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_WORLD, string.Format("!!additem id={0} num={1} str={2} ql={3}", new object[]
				{
					valueFromUnionCell2,
					1,
					strength,
					"100"
				}), 0UL, 0);
			}
		}
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x0005BFAC File Offset: 0x0005A3AC
	public static void ClearChild(GameObject go)
	{
		int childCount = go.transform.childCount;
		if (childCount <= 0)
		{
			return;
		}
		for (int i = 0; i < childCount; i++)
		{
			GameObject gameObject = go.transform.GetChild(i).gameObject;
			if (gameObject != null)
			{
				Object.Destroy(gameObject);
			}
		}
	}

	// Token: 0x06001173 RID: 4467 RVA: 0x0005C004 File Offset: 0x0005A404
	public static void ClearChild(GameObject parent, int index)
	{
		int childCount = parent.transform.childCount;
		if (childCount <= 0)
		{
			return;
		}
		for (int i = 0; i < childCount; i++)
		{
			if (i == index)
			{
				GameObject gameObject = parent.transform.GetChild(i).gameObject;
				if (gameObject != null)
				{
					Object.Destroy(gameObject);
				}
				break;
			}
		}
	}

	// Token: 0x06001174 RID: 4468 RVA: 0x0005C068 File Offset: 0x0005A468
	public static string GetBuffPrayActivityEffectPath(int index)
	{
		string result = string.Empty;
		switch (index)
		{
		case 1:
			result = TR.Value("effUI_qianghuaquanhecheng_fuwen01");
			break;
		case 2:
			result = TR.Value("effUI_qianghuaquanhecheng_fuwen02");
			break;
		case 3:
			result = TR.Value("effUI_qianghuaquanhecheng_fuwen03");
			break;
		case 4:
			result = TR.Value("effUI_qianghuaquanhecheng_fuwen04");
			break;
		case 5:
			result = TR.Value("effUI_qianghuaquanhecheng_fuwen05");
			break;
		default:
			result = TR.Value("effUI_qianghuaquanhecheng_fuwen01");
			break;
		}
		return result;
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x0005C100 File Offset: 0x0005A500
	public static int GetPetID(int petEggID)
	{
		int result = 0;
		foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<PetTable>())
		{
			PetTable petTable = keyValuePair.Value as PetTable;
			if (petTable.PetEggID == petEggID)
			{
				return petTable.ID;
			}
		}
		return result;
	}

	// Token: 0x06001176 RID: 4470 RVA: 0x0005C160 File Offset: 0x0005A560
	public static GameObject AddModelToActor(string resPath, GeActorEx geActor, GameObject attachNode)
	{
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(resPath, true, 0U);
		Utility.AttachTo(gameObject, attachNode, false);
		return gameObject;
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x0005C184 File Offset: 0x0005A584
	public static string Combine(string path1, string path2)
	{
		string path3 = Path.Combine(path1, path2);
		return Utility.Normalize(path3);
	}

	// Token: 0x06001178 RID: 4472 RVA: 0x0005C19F File Offset: 0x0005A59F
	public static string Normalize(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return path;
		}
		return path.Replace('\\', '/');
	}

	// Token: 0x06001179 RID: 4473 RVA: 0x0005C1B8 File Offset: 0x0005A5B8
	public static void DoStartFrameOperation(string sFrameName, string sButtonName)
	{
		string dateTime = Function.GetDateTime((int)DataManager<TimeManager>.GetInstance().GetServerTime(), true);
		Singleton<GameStatisticManager>.GetInstance().DoStartFrameOperation(sFrameName, sButtonName, dateTime);
	}

	// Token: 0x0600117A RID: 4474 RVA: 0x0005C1E4 File Offset: 0x0005A5E4
	public static void SetPersonalInfo(DisplayAttribute attribute, GameObject objLeftRoot, GameObject objRightRoot)
	{
		for (int i = 0; i < 51; i++)
		{
			AttributeType attributeType = (AttributeType)i;
			if (attributeType != AttributeType.abnormalResist)
			{
				string attributeString = Global.GetAttributeString((AttributeType)i);
				GameObject gameObject = Utility.FindGameObject(objLeftRoot, attributeString, false);
				if (gameObject == null)
				{
					gameObject = Utility.FindGameObject(objRightRoot, attributeString, false);
					if (gameObject == null)
					{
						goto IL_188;
					}
				}
				GameObject gameObject2 = Utility.FindGameObject(gameObject, "Value", true);
				if (!(gameObject2 == null))
				{
					FieldInfo field = attribute.GetType().GetField(attributeString);
					float num = 0f;
					if (field != null)
					{
						num = (float)field.GetValue(attribute);
					}
					Text component = gameObject2.GetComponent<Text>();
					component.color = Color.white;
					if (attribute.attachValue.ContainsKey(attributeString))
					{
						if (attribute.attachValue[attributeString] > 0)
						{
							component.color = Color.green;
						}
						else if (attribute.attachValue[attributeString] < 0)
						{
							component.color = Color.red;
						}
					}
					if (attributeType == AttributeType.attackSpeed || attributeType == AttributeType.moveSpeed || attributeType == AttributeType.spellSpeed || attributeType == AttributeType.ciriticalAttack || attributeType == AttributeType.ciriticalMagicAttack || attributeType == AttributeType.dex || attributeType == AttributeType.dodge)
					{
						string text = "{0:F1}%";
						if (num > 0f)
						{
							text = "+" + text;
						}
						component.text = string.Format(text, num);
					}
					else
					{
						component.text = string.Format("{0}", num);
					}
				}
			}
			IL_188:;
		}
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x0005C388 File Offset: 0x0005A788
	public static ItemData _TryAddFashionItem(ulong guid)
	{
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
		if (item == null || item.Type != ItemTable.eType.FASHION || item.PackageType == EPackageType.Storage || item.PackageType == EPackageType.RoleStorage)
		{
			return null;
		}
		return item;
	}

	// Token: 0x0600117C RID: 4476 RVA: 0x0005C3D0 File Offset: 0x0005A7D0
	public static int _SortFashion(ItemData left, ItemData right)
	{
		if (left.FashionWearSlotType != right.FashionWearSlotType)
		{
			return left.FashionWearSlotType - right.FashionWearSlotType;
		}
		if (left.Quality != right.Quality)
		{
			return left.Quality - right.Quality;
		}
		return (int)(left.GUID - right.GUID);
	}

	// Token: 0x0600117D RID: 4477 RVA: 0x0005C42C File Offset: 0x0005A82C
	public static ItemData _TryAddMagicCard(ulong guid)
	{
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
		if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25 && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage)
		{
			return item;
		}
		return null;
	}

	// Token: 0x0600117E RID: 4478 RVA: 0x0005C480 File Offset: 0x0005A880
	public static bool _CheckFashionCanMerge(ulong guid)
	{
		ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
		if (item == null)
		{
			return false;
		}
		if (item.bFashionItemLocked)
		{
			return false;
		}
		if (item.Type != ItemTable.eType.FASHION)
		{
			return false;
		}
		if (item.PackageType != EPackageType.Fashion)
		{
			return false;
		}
		if (item.PackageType == EPackageType.Storage || item.PackageType == EPackageType.RoleStorage)
		{
			return false;
		}
		if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
		{
			FashionComposeSkyTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.Type < 10000)
			{
				return false;
			}
		}
		else
		{
			FashionComposeSkyTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				return false;
			}
		}
		if (item.SubType == 11)
		{
			return false;
		}
		if (item.SubType == 81)
		{
			return false;
		}
		if (item.SubType == 92)
		{
			return false;
		}
		if (item.Quality == ItemTable.eColor.PINK)
		{
			return false;
		}
		ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
		return tableItem3 != null && (tableItem3.TimeLeft <= 0 || item.DeadTimestamp == 0);
	}

	// Token: 0x0600117F RID: 4479 RVA: 0x0005C5D0 File Offset: 0x0005A9D0
	public static int BinarySearch(IList<int> nums, int val)
	{
		int i = 0;
		int num = nums.Count - 1;
		while (i <= num)
		{
			int num2 = (i + num) / 2;
			if (nums[num2] > val)
			{
				num = num2 - 1;
			}
			else
			{
				if (nums[num2] >= val)
				{
					return num2;
				}
				i = num2 + 1;
			}
		}
		return i;
	}

	// Token: 0x06001180 RID: 4480 RVA: 0x0005C62C File Offset: 0x0005AA2C
	public static void CommonPopupWindow(string content, OnCommonMsgBoxToggleClick onToggleClick, Action onRureClick)
	{
		SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(new CommonMsgBoxOkCancelNewParamData
		{
			ContentLabel = content,
			IsShowNotify = true,
			OnCommonMsgBoxToggleClick = onToggleClick,
			LeftButtonText = TR.Value("common_data_cancel"),
			RightButtonText = TR.Value("common_data_sure"),
			OnRightButtonClickCallBack = onRureClick
		});
	}

	// Token: 0x06001181 RID: 4481 RVA: 0x0005C684 File Offset: 0x0005AA84
	public static string GetWriteablePath()
	{
		string result;
		if (Application.platform == 8)
		{
			result = Utility.GetPersistentDataPath() + "/";
		}
		else if (Application.platform == 11)
		{
			result = Utility.GetPersistentDataPath() + "/";
		}
		else if (Application.platform == 2)
		{
			result = Application.dataPath + "/";
		}
		else
		{
			result = Application.dataPath + "/";
		}
		return result;
	}

	// Token: 0x06001182 RID: 4482 RVA: 0x0005C705 File Offset: 0x0005AB05
	public static string GetPersistentDataPath()
	{
		return Application.persistentDataPath;
	}

	// Token: 0x06001183 RID: 4483 RVA: 0x0005C70C File Offset: 0x0005AB0C
	public static string GetItemModulePath(int itemID)
	{
		string result = null;
		ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.ResID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				result = tableItem2.ModelPath;
			}
		}
		return result;
	}

	// Token: 0x06001184 RID: 4484 RVA: 0x0005C760 File Offset: 0x0005AB60
	public static bool CheckTeamEnterGuildDungeon()
	{
		if (DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus() != GuildDungeonStatus.GUILD_DUNGEON_START)
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonNotOpenTip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			return false;
		}
		if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("enterGuildDungeonLimitTip1"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			return false;
		}
		if (DataManager<GuildDataManager>.GetInstance().myGuild.nLevel < GuildDataManager.GetGuildDungeonActivityGuildLvLimit())
		{
			SystemNotifyManager.SystemNotify(2317007, string.Empty);
			return false;
		}
		if ((int)DataManager<PlayerBaseData>.GetInstance().Level < GuildDataManager.GetGuildDungeonActivityPlayerLvLimit())
		{
			SystemNotifyManager.SystemNotify(2317008, string.Empty);
			return false;
		}
		return Utility.CheckSameGuildInTeam() && Utility.CheckMemberLvInTeam();
	}

	// Token: 0x06001185 RID: 4485 RVA: 0x0005C81C File Offset: 0x0005AC1C
	public static bool CheckTeamEnterDungeonCondition(int iTeamDungeonTableID)
	{
		if (Global.Settings.CloseTeamCondition)
		{
			return true;
		}
		if (Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(iTeamDungeonTableID, string.Empty, string.Empty) == null)
		{
			return false;
		}
		int num = 0;
		if (!Utility.CheckTeamCondition(iTeamDungeonTableID, ref num))
		{
			if (num == 1008)
			{
				SystemNotifyManager.SystemNotify(1108, string.Empty);
			}
			else if (num == 1107)
			{
				SystemNotifyManager.SystemNotify(1109, string.Empty);
			}
			else if (num == 900014)
			{
				SystemNotifyManager.SystemNotify(900014, string.Empty);
			}
			return false;
		}
		return true;
	}

	// Token: 0x06001186 RID: 4486 RVA: 0x0005C8C4 File Offset: 0x0005ACC4
	public static bool CheckJoinTeamCondition(ulong teamLeaderID, ref int NotifyID)
	{
		if (Global.Settings.CloseTeamCondition)
		{
			return true;
		}
		List<Team> teamList = DataManager<TeamDataManager>.GetInstance().GetTeamList();
		if (teamList == null || teamList.Count < 1)
		{
			return false;
		}
		int i = 0;
		while (i < teamList.Count)
		{
			Team team = teamList[i];
			if (team.leaderInfo.id != teamLeaderID)
			{
				i++;
			}
			else
			{
				if (DataManager<TeamDataManager>.GetInstance().TeamDungeonID == 1U)
				{
					return true;
				}
				if (!Utility.CheckTeamCondition((int)team.teamDungeonID, ref NotifyID))
				{
					return false;
				}
				break;
			}
		}
		return true;
	}

	// Token: 0x06001187 RID: 4487 RVA: 0x0005C964 File Offset: 0x0005AD64
	public static bool CheckTeamCondition(int iTeamDungeonTableID, ref int NotifyID)
	{
		if (Global.Settings.CloseTeamCondition)
		{
			return true;
		}
		TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(iTeamDungeonTableID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return false;
		}
		if (tableItem.MinLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
		{
			NotifyID = 1008;
			return false;
		}
		if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
		{
			return true;
		}
		DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
		if (tableItem2 != null && tableItem2.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON)
		{
			return true;
		}
		if ((tableItem2 != null && tableItem2.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL) || tableItem2.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMIT_TIME_HELL);
			if (activeDataFromType == null)
			{
				NotifyID = 900014;
				return false;
			}
			if (activeDataFromType.state == 1)
			{
				return true;
			}
			NotifyID = 900014;
			return false;
		}
		else
		{
			if (tableItem2 != null && tableItem2.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY)
			{
				return DungeonUtility.GetWeekHellPreTaskState(tableItem2.ID) == WeekHellPreTaskState.IsFinished;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty) == null)
			{
				return false;
			}
			if (!ChapterUtility.GetDungeonCanEnter(tableItem.DungeonID, false, false, true))
			{
				NotifyID = 1107;
				return false;
			}
			return true;
		}
	}

	// Token: 0x06001188 RID: 4488 RVA: 0x0005CABC File Offset: 0x0005AEBC
	public static bool CheckMemberLvInTeam()
	{
		Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
		if (myTeam == null)
		{
			return false;
		}
		for (int i = 0; i < myTeam.members.Length; i++)
		{
			if (myTeam.members[i].id != 0UL)
			{
				if ((int)myTeam.members[i].level < GuildDataManager.GetGuildDungeonActivityPlayerLvLimit())
				{
					string name = myTeam.members[i].name;
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format(TR.Value("enterGuildDungeonLimitTip2"), name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x0005CB50 File Offset: 0x0005AF50
	public static bool CheckSameGuildInTeam()
	{
		Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
		if (myTeam == null)
		{
			return false;
		}
		for (int i = 0; i < myTeam.members.Length; i++)
		{
			if (myTeam.members[i].id != 0UL)
			{
				if (!DataManager<GuildDataManager>.GetInstance().IsSameGuild(myTeam.members[i].guildid))
				{
					string name = myTeam.members[i].name;
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format(TR.Value("enterGuildDungeonLimitTip3"), name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x0600118A RID: 4490 RVA: 0x0005CBE8 File Offset: 0x0005AFE8
	public static bool CheckIsTeamDungeon(int iDungeonID, ref int TeamDungeonTableID)
	{
		if (Global.Settings.CloseTeamCondition)
		{
			return true;
		}
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<TeamDungeonTable>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			TeamDungeonTable teamDungeonTable = keyValuePair.Value as TeamDungeonTable;
			if (teamDungeonTable.DungeonID == iDungeonID)
			{
				TeamDungeonTableID = teamDungeonTable.ID;
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600118B RID: 4491 RVA: 0x0005CC58 File Offset: 0x0005B058
	public static List<int> GetTeamDungeonMenuFliterList(ref Dictionary<int, List<int>> SecFliterDict)
	{
		List<int> list = new List<int>();
		List<int> teamDungeonFirstMenuList = Singleton<TableManager>.GetInstance().GetTeamDungeonFirstMenuList();
		if (teamDungeonFirstMenuList == null)
		{
			return list;
		}
		int num = 0;
		for (int i = 0; i < teamDungeonFirstMenuList.Count; i++)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonFirstMenuList[i], string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.ID == 1)
				{
					list.Add(tableItem.ID);
				}
				else
				{
					List<int> list2 = new List<int>();
					List<int> list3 = new List<int>();
					Dictionary<int, List<int>> teamDungeonSecondMenuDict = Singleton<TableManager>.GetInstance().GetTeamDungeonSecondMenuDict();
					if (teamDungeonSecondMenuDict.TryGetValue(teamDungeonFirstMenuList[i], out list3))
					{
						bool flag = false;
						for (int j = 0; j < list3.Count; j++)
						{
							TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(list3[j], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (Utility.CheckTeamCondition(list3[j], ref num))
								{
									list2.Add(tableItem2.ID);
									flag = true;
								}
							}
						}
						if (flag)
						{
							list.Add(tableItem.ID);
							SecFliterDict.Add(tableItem.ID, list2);
						}
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0600118C RID: 4492 RVA: 0x0005CDB0 File Offset: 0x0005B1B0
	public static void CalTeamFirstAndSecondMenuIndex(int iTeamDungeonTableID, ref int iFirstMenuIndex, ref int iSecondMenuIndex)
	{
		if (iTeamDungeonTableID == 1)
		{
			iFirstMenuIndex = 0;
			iSecondMenuIndex = -1;
			return;
		}
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		Utility.GetTeamDungeonMenuFliterList(ref dictionary);
		Dictionary<int, List<int>>.Enumerator enumerator = dictionary.GetEnumerator();
		int num = 1;
		while (enumerator.MoveNext())
		{
			KeyValuePair<int, List<int>> keyValuePair = enumerator.Current;
			List<int> value = keyValuePair.Value;
			bool flag = false;
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] == iTeamDungeonTableID)
				{
					iSecondMenuIndex = i;
					flag = true;
					break;
				}
			}
			if (flag)
			{
				iFirstMenuIndex = num;
				break;
			}
			num++;
		}
	}

	// Token: 0x0600118D RID: 4493 RVA: 0x0005CE50 File Offset: 0x0005B250
	public static void OpenTeamFrame(int iDungeonId)
	{
		int num = 0;
		if (!Utility.CheckIsTeamDungeon(iDungeonId, ref num))
		{
			return;
		}
		int num2 = 0;
		if (!Utility.CheckTeamCondition(num, ref num2))
		{
			SystemNotifyManager.SystemNotify(1107, string.Empty);
			return;
		}
		if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
		{
			int num3 = num;
			TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(num3, string.Empty, string.Empty);
			if (tableItem != null && (tableItem.Type == TeamDungeonTable.eType.DUNGEON || tableItem.Type == TeamDungeonTable.eType.CityMonster))
			{
				DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.Target, num3);
			}
		}
		Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, num, string.Empty);
	}

	// Token: 0x0600118E RID: 4494 RVA: 0x0005CEF4 File Offset: 0x0005B2F4
	public static string GetGuildPositionName(int position)
	{
		EGuildDuty clientDuty = DataManager<GuildDataManager>.GetInstance().GetClientDuty((byte)position);
		if (clientDuty <= EGuildDuty.Invalid || clientDuty > EGuildDuty.Leader)
		{
			return "-";
		}
		return TR.Value(clientDuty.GetDescription(true));
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x0005CF34 File Offset: 0x0005B334
	public static ComItem AddItemIcon(ClientFrame frame, GameObject parent, uint itemID, int itemNum, int strengthLevel = 0)
	{
		ComItem comItem = frame.CreateComItem(parent);
		ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)itemID, 100, strengthLevel);
		if (strengthLevel > 0)
		{
			itemData.StrengthenLevel = strengthLevel;
		}
		itemData.Count = itemNum;
		comItem.Setup(itemData, delegate(GameObject obj, ItemData item1)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(item1, null, 4, true, false, true);
		});
		return comItem;
	}

	// Token: 0x06001190 RID: 4496 RVA: 0x0005CF90 File Offset: 0x0005B390
	public static void EnterGuildBattle()
	{
		if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
		{
			SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_have_no_guild"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			return;
		}
		Singleton<ClientSystemManager>.instance.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenManorFrame, null, null, null, null);
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x0005CFE4 File Offset: 0x0005B3E4
	public static bool HasNewFunc()
	{
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<FunctionUnLock>();
		foreach (KeyValuePair<int, object> keyValuePair in table)
		{
			FunctionUnLock functionUnLock = keyValuePair.Value as FunctionUnLock;
			if (functionUnLock != null && functionUnLock.bPlayAnim == 1 && functionUnLock.FinishLevel == (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001192 RID: 4498 RVA: 0x0005D054 File Offset: 0x0005B454
	public static string To10K(ulong nNumber)
	{
		float num = nNumber / 10000f;
		int num2 = (int)(num * 100f);
		return ((float)((double)num2 * 1.0) / 100f).ToString("f2") + "万";
	}

	// Token: 0x06001193 RID: 4499 RVA: 0x0005D0A0 File Offset: 0x0005B4A0
	public static string ToThousandsSeparator(ulong nNumber)
	{
		if (string.IsNullOrEmpty(nNumber.ToString()))
		{
			return string.Empty;
		}
		string text = new string(nNumber.ToString().ToCharArray());
		if (text == null)
		{
			return string.Empty;
		}
		for (int i = text.Length - 3; i > 0; i -= 3)
		{
			text = text.Insert(i, ",");
		}
		return text;
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x0005D118 File Offset: 0x0005B518
	public static string GetShowPrice(ulong uPrice, bool bUseToMillion = false)
	{
		if (uPrice < 10000UL)
		{
			return uPrice.ToString();
		}
		if (uPrice < 10000UL || uPrice >= 100000000UL)
		{
			string arg = (uPrice / 100000000f).ToString("F2");
			return string.Format("{0}亿", arg);
		}
		if (bUseToMillion)
		{
			return string.Format("{0}万", uPrice / 10000f);
		}
		return uPrice.ToString();
	}

	// Token: 0x06001195 RID: 4501 RVA: 0x0005D1A8 File Offset: 0x0005B5A8
	public static bool EnterBudo()
	{
		if (!DataManager<BudoManager>.GetInstance().IsOpen || DataManager<BudoManager>.GetInstance().CanParty)
		{
			BoduInfoFrame.Open(1);
			return false;
		}
		if (DataManager<BudoManager>.GetInstance().CanAcqured)
		{
			BudoResultFrame.Open(new BudoResultFrameData
			{
				bOver = true,
				bNeedOpenBudoInfo = true
			});
			return false;
		}
		DataManager<BudoManager>.GetInstance().GotoPvpBudo();
		return true;
	}

	// Token: 0x06001196 RID: 4502 RVA: 0x0005D214 File Offset: 0x0005B614
	public static void CalShowUplevelGiftIndex(ActiveManager.ActiveData activeData, ref int iCanReceiveIdx, ref int iUnFinishIdx)
	{
		if (activeData.akChildItems == null)
		{
			return;
		}
		for (int i = 0; i < activeData.akChildItems.Count; i++)
		{
			if (activeData.akChildItems[i].status == 2)
			{
				iCanReceiveIdx = i;
				break;
			}
			if (activeData.akChildItems[i].status < 2 && iUnFinishIdx == -1)
			{
				iUnFinishIdx = i;
			}
		}
	}

	// Token: 0x06001197 RID: 4503 RVA: 0x0005D28C File Offset: 0x0005B68C
	public static int GetDayOnLineTime()
	{
		int result = 0;
		int num = 5000;
		if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.ContainsKey(num))
		{
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().ActiveDictionary[num];
			if (activeData != null)
			{
				ActiveManager.ActiveMainUpdateKey activeMainUpdateKey = null;
				for (int i = 0; i < activeData.updateMainKeys.Count; i++)
				{
					if (activeData.updateMainKeys[i].key == "DayOnline")
					{
						activeMainUpdateKey = activeData.updateMainKeys[i];
						break;
					}
				}
				if (activeMainUpdateKey == null)
				{
					return result;
				}
				int templateUpdateValue = DataManager<ActiveManager>.GetInstance().GetTemplateUpdateValue(num, activeMainUpdateKey.key, 0);
				int num2 = (int)(DataManager<TimeManager>.GetInstance().GetServerTime() - (uint)((int)activeMainUpdateKey.fRecievedTime));
				result = templateUpdateValue + num2;
			}
		}
		return result;
	}

	// Token: 0x06001198 RID: 4504 RVA: 0x0005D35C File Offset: 0x0005B75C
	public static string GetJobName(int iJobID, int iAwakeState = 0)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(iJobID, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		if (tableItem.JobType == 0)
		{
			return tableItem.Name;
		}
		if (iAwakeState == 0)
		{
			return tableItem.Name;
		}
		if (iAwakeState - 1 >= 0 && iAwakeState - 1 < tableItem.AwakenJobName.Count)
		{
			return tableItem.AwakenJobName[iAwakeState - 1];
		}
		return tableItem.Name;
	}

	// Token: 0x06001199 RID: 4505 RVA: 0x0005D3DC File Offset: 0x0005B7DC
	public static int GetLeftLimitNum(MallItemInfo ItemInfo, ref bool bIsDailyLimit)
	{
		int result = 0;
		if (ItemInfo.gift == 1)
		{
			if (ItemInfo.limitnum >= 0 && ItemInfo.limitnum < 65535)
			{
				result = (int)ItemInfo.limitnum;
				bIsDailyLimit = true;
			}
			else if (ItemInfo.limittotalnum >= 0 && ItemInfo.limittotalnum < 65535)
			{
				result = (int)ItemInfo.limittotalnum;
			}
		}
		else if (ItemInfo.limitnum > 0 && ItemInfo.limitnum < 65535)
		{
			result = (int)ItemInfo.limitnum - DataManager<CountDataManager>.GetInstance().GetCount(ItemInfo.id.ToString());
			bIsDailyLimit = true;
		}
		else if (ItemInfo.limittotalnum > 0 && ItemInfo.limittotalnum < 65535)
		{
			result = (int)ItemInfo.limittotalnum - DataManager<CountDataManager>.GetInstance().GetCount(ItemInfo.id.ToString());
		}
		return result;
	}

	// Token: 0x0600119A RID: 4506 RVA: 0x0005D4D4 File Offset: 0x0005B8D4
	public static int GetBaseJobID(int JobID)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(JobID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			if (tableItem.JobType == 0)
			{
				return JobID;
			}
			if (tableItem.JobType == 1)
			{
				return tableItem.prejob;
			}
		}
		return 0;
	}

	// Token: 0x0600119B RID: 4507 RVA: 0x0005D520 File Offset: 0x0005B920
	public static int GetBetterJobId(int jobId)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return 0;
		}
		if (tableItem.JobType == 1)
		{
			return jobId;
		}
		Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
		if (table != null)
		{
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				JobTable jobTable = keyValuePair.Value as JobTable;
				if (jobTable != null && jobTable.Open == 1 && jobTable.JobType == 1 && jobTable.prejob == jobId)
				{
					return jobTable.ID;
				}
			}
		}
		return 0;
	}

	// Token: 0x0600119C RID: 4508 RVA: 0x0005D5CC File Offset: 0x0005B9CC
	public static ItemData GetItemDataFromTableWithIdCount(string itemInfo_Id_Count)
	{
		if (string.IsNullOrEmpty(itemInfo_Id_Count))
		{
			return null;
		}
		string[] array = itemInfo_Id_Count.Split(new char[]
		{
			'_'
		});
		if (array == null || array.Length != 2)
		{
			Logger.LogErrorFormat("[Utility] - GetItemDataFromTableWithIdCount itemInfo format is error !", new object[0]);
			return null;
		}
		int tableId = 0;
		int count = 0;
		ItemData itemData = null;
		if (int.TryParse(array[0], out tableId) && int.TryParse(array[1], out count))
		{
			itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
			if (itemData != null)
			{
				itemData.Count = count;
			}
		}
		return itemData;
	}

	// Token: 0x0600119D RID: 4509 RVA: 0x0005D658 File Offset: 0x0005BA58
	public static ItemSimpleData GetItemSimpleDataFromTableWithIdCount(string itemInfo_Id_Count)
	{
		if (string.IsNullOrEmpty(itemInfo_Id_Count))
		{
			return null;
		}
		string[] array = itemInfo_Id_Count.Split(new char[]
		{
			'_'
		});
		if (array == null || array.Length != 2)
		{
			Logger.LogErrorFormat("[Utility] - GetItemDataFromTableWithIdCount itemInfo format is error !", new object[0]);
			return null;
		}
		int num = 0;
		int count = 0;
		ItemSimpleData itemSimpleData = null;
		if (int.TryParse(array[0], out num) && int.TryParse(array[1], out count))
		{
			string ownedItemName = DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(num);
			if (string.IsNullOrEmpty(ownedItemName))
			{
				return itemSimpleData;
			}
			itemSimpleData = new ItemSimpleData(num, count);
			itemSimpleData.Name = ownedItemName;
		}
		return itemSimpleData;
	}

	// Token: 0x0600119E RID: 4510 RVA: 0x0005D6F8 File Offset: 0x0005BAF8
	public static string GetUnitNumWithHeadZero(int num, bool startZero)
	{
		int num2 = num;
		if (startZero)
		{
			num2++;
		}
		string text = num2.ToString();
		if (num2 < 10)
		{
			text = string.Format("0{0}", text);
		}
		return text;
	}

	// Token: 0x0600119F RID: 4511 RVA: 0x0005D734 File Offset: 0x0005BB34
	public static bool CheckPackageGridFullByPackageType(EPackageType ePackageType)
	{
		bool result = false;
		int num = 0;
		int num2 = 0;
		List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(ePackageType);
		if (itemsByPackageType != null)
		{
			num = itemsByPackageType.Count;
		}
		List<int> packTotalSize = DataManager<PlayerBaseData>.GetInstance().PackTotalSize;
		if (packTotalSize != null && packTotalSize.Count > (int)ePackageType)
		{
			num2 = packTotalSize[(int)ePackageType];
		}
		if (num >= num2)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060011A0 RID: 4512 RVA: 0x0005D798 File Offset: 0x0005BB98
	public static string GetRoleIconByRoleId(int jobTableId)
	{
		JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableId, string.Empty, string.Empty);
		if (tableItem != null)
		{
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				return tableItem2.IconPath;
			}
		}
		return string.Empty;
	}

	// Token: 0x060011A1 RID: 4513 RVA: 0x0005D7F0 File Offset: 0x0005BBF0
	public static void SetPopMenuPosition(GameObject m_objMenu, Vector2 bounder = default(Vector2), Vector2 offSet = default(Vector2))
	{
		if (m_objMenu == null)
		{
			return;
		}
		RectTransform component = m_objMenu.GetComponent<RectTransform>();
		RectTransform rectTransform = component.transform.parent as RectTransform;
		if (component == null || rectTransform == null)
		{
			return;
		}
		Vector2 vector;
		vector..ctor(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 vector2;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, vector, Singleton<ClientSystemManager>.GetInstance().UICamera, ref vector2))
		{
			return;
		}
		LayoutRebuilder.ForceRebuildLayoutImmediate(component);
		float num = (float)(Screen.width / 2);
		float num2 = component.rect.width / 2f;
		float num3 = component.rect.height / 2f;
		Vector2 size = rectTransform.rect.size;
		Vector2 anchoredPosition;
		if (vector.x >= num)
		{
			anchoredPosition..ctor(vector2.x - num2, vector2.y);
		}
		else
		{
			anchoredPosition..ctor(vector2.x + num2, vector2.y);
		}
		float num4 = -size.x / 2f + bounder.x + num2;
		float num5 = size.x / 2f - bounder.x - num2;
		float num6 = size.y / 2f - bounder.y - num3;
		float num7 = -(size.y / 2f - bounder.y - num3);
		anchoredPosition.x = Mathf.Clamp(anchoredPosition.x + offSet.x, num4, num5);
		anchoredPosition.y = Mathf.Clamp(anchoredPosition.y + offSet.y, num7, num6);
		component.anchoredPosition = anchoredPosition;
	}

	// Token: 0x060011A2 RID: 4514 RVA: 0x0005D9BC File Offset: 0x0005BDBC
	public static int GetPlayerMaxLevel()
	{
		TableManager instance = Singleton<TableManager>.GetInstance();
		if (instance != null)
		{
			SystemValueTable tableItem = instance.GetTableItem<SystemValueTable>(180, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Value;
			}
		}
		Logger.LogErrorFormat("can`t get player`s max level,check systemValueTable", new object[0]);
		return 65;
	}

	// Token: 0x04000B4A RID: 2890
	private static ulong[] _DW = new ulong[]
	{
		10000000000UL,
		100000000UL,
		1000000UL,
		10000UL,
		100UL
	};

	// Token: 0x04000B4B RID: 2891
	private static readonly int CHINESE_CHAR_END = Convert.ToInt32("9fff", 16);

	// Token: 0x04000B4C RID: 2892
	private static readonly int CHINESE_CHAR_START = Convert.ToInt32("4e00", 16);

	// Token: 0x04000B4D RID: 2893
	private static readonly int MAX_CHINESE_NAME_LEN = 12;

	// Token: 0x04000B4E RID: 2894
	private static readonly int MAX_EN_NAME_LEN = 9;

	// Token: 0x04000B4F RID: 2895
	private static readonly int MIN_CHINESE_NAME_LEN = 4;

	// Token: 0x04000B50 RID: 2896
	private static readonly int MIN_EN_NAME_LEN = 3;

	// Token: 0x04000B51 RID: 2897
	public static uint s_daySecond = 86400U;

	// Token: 0x04000B52 RID: 2898
	public const long UTC_OFFSET_LOCAL = 28800L;

	// Token: 0x04000B53 RID: 2899
	public const long UTCTICK_PER_SECONDS = 10000000L;

	// Token: 0x04000B54 RID: 2900
	private const float PRECISION = 1E-06f;

	// Token: 0x04000B55 RID: 2901
	public const string kRawDataPrefix = "RawData";

	// Token: 0x04000B56 RID: 2902
	public const string kRawDataExtension = ".bytes";

	// Token: 0x04000B57 RID: 2903
	private static readonly int[] layerTbl = new int[]
	{
		12,
		15,
		16,
		17
	};

	// Token: 0x04000B58 RID: 2904
	private static CultureInfo mCultureInfo = new CultureInfo("zh-CN");

	// Token: 0x04000B59 RID: 2905
	private static List<JobTable> betterJobIds = new List<JobTable>();

	// Token: 0x04000B5A RID: 2906
	private static List<JobTable> ms_akAllJobsID = new List<JobTable>();

	// Token: 0x04000B5B RID: 2907
	private static Regex[] ms_missionkey_regex = new Regex[]
	{
		new Regex("<key>key=(\\w+)</key>"),
		new Regex("<key>key=(\\w+)/value=(\\d+)</key>"),
		new Regex("<key>key=(\\w+)/key=(\\w+)</key>")
	};

	// Token: 0x02000207 RID: 519
	public enum SoundKind
	{
		// Token: 0x04000B5E RID: 2910
		SK_ACCEPT_TASK,
		// Token: 0x04000B5F RID: 2911
		SK_COMPLETE_TASK,
		// Token: 0x04000B60 RID: 2912
		SK_ABANDON_TASK,
		// Token: 0x04000B61 RID: 2913
		SK_ACQUIRE_AWARD,
		// Token: 0x04000B62 RID: 2914
		SK_OPEN_FRAME,
		// Token: 0x04000B63 RID: 2915
		SK_CLOSE_FRAME
	}

	// Token: 0x02000208 RID: 520
	private enum MissionKeyType
	{
		// Token: 0x04000B65 RID: 2917
		MKT_KEY,
		// Token: 0x04000B66 RID: 2918
		MKT_KEY_VALUE,
		// Token: 0x04000B67 RID: 2919
		MKT_KEY_KEY,
		// Token: 0x04000B68 RID: 2920
		MKT_COUNT
	}

	// Token: 0x02000209 RID: 521
	public class ContentProcess
	{
		// Token: 0x060011A7 RID: 4519 RVA: 0x0005DB1A File Offset: 0x0005BF1A
		public ContentProcess()
		{
			this.content = null;
			this.iPreValue = 0;
			this.iAftValue = 1;
			this.bFinish = false;
			this.fAmount = 0f;
		}

		// Token: 0x04000B69 RID: 2921
		public string content;

		// Token: 0x04000B6A RID: 2922
		public int iPreValue;

		// Token: 0x04000B6B RID: 2923
		public int iAftValue;

		// Token: 0x04000B6C RID: 2924
		public bool bFinish;

		// Token: 0x04000B6D RID: 2925
		public float fAmount;
	}

	// Token: 0x0200020A RID: 522
	public class TipContent
	{
		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060011A9 RID: 4521 RVA: 0x0005DB72 File Offset: 0x0005BF72
		public bool IsNull
		{
			get
			{
				return string.IsNullOrEmpty(this.left) && string.IsNullOrEmpty(this.right);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060011AA RID: 4522 RVA: 0x0005DB92 File Offset: 0x0005BF92
		public string Prefabpath
		{
			get
			{
				return this.prefabs;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x0005DB9A File Offset: 0x0005BF9A
		// (set) Token: 0x060011AC RID: 4524 RVA: 0x0005DBA4 File Offset: 0x0005BFA4
		public Utility.TipContent.TipContentType ETipContentType
		{
			get
			{
				return this.eTipContentType;
			}
			set
			{
				this.eTipContentType = value;
				if (this.eTipContentType > Utility.TipContent.TipContentType.TCT_INVALID && this.eTipContentType < Utility.TipContent.TipContentType.TCT_COUNT)
				{
					this.prefabs = Utility.TipContent.ms_prefabspaths[(int)this.eTipContentType];
				}
				else
				{
					this.prefabs = string.Empty;
				}
			}
		}

		// Token: 0x04000B6E RID: 2926
		public int iParam0;

		// Token: 0x04000B6F RID: 2927
		public string left = string.Empty;

		// Token: 0x04000B70 RID: 2928
		public string right = string.Empty;

		// Token: 0x04000B71 RID: 2929
		private string prefabs = string.Empty;

		// Token: 0x04000B72 RID: 2930
		private Utility.TipContent.TipContentType eTipContentType;

		// Token: 0x04000B73 RID: 2931
		public static string[] ms_prefabspaths = new string[]
		{
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefabLWFixed",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartPrefab",
			"UIFlatten/Prefabs/TitleBookFrame/SmartBlank"
		};

		// Token: 0x0200020B RID: 523
		public enum TipContentType
		{
			// Token: 0x04000B75 RID: 2933
			TCT_INVALID = -1,
			// Token: 0x04000B76 RID: 2934
			TCT_LEVEL_LIMIT,
			// Token: 0x04000B77 RID: 2935
			TCT_BASEATTR,
			// Token: 0x04000B78 RID: 2936
			TCT_STRENGTH_DESC,
			// Token: 0x04000B79 RID: 2937
			TCT_PHYSIC_ATTACK,
			// Token: 0x04000B7A RID: 2938
			TCT_FOUR_ATTR,
			// Token: 0x04000B7B RID: 2939
			TCT_SKILL_ATTR,
			// Token: 0x04000B7C RID: 2940
			TCT_ATTACH_ATTR,
			// Token: 0x04000B7D RID: 2941
			TCT_COM_ATTR,
			// Token: 0x04000B7E RID: 2942
			TCT_TIMESTAMP_ATTR,
			// Token: 0x04000B7F RID: 2943
			TCT_INTERESTING_DESC,
			// Token: 0x04000B80 RID: 2944
			TCT_SOURCE_DESC,
			// Token: 0x04000B81 RID: 2945
			TCT_BLANK_DESC,
			// Token: 0x04000B82 RID: 2946
			TCT_COUNT
		}
	}

	// Token: 0x0200020C RID: 524
	public class DailyProveTaskConfig
	{
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x0005DC78 File Offset: 0x0005C078
		public float Amount
		{
			get
			{
				float num = 0f;
				if (this.iAftValue != 0)
				{
					num = (float)this.iPreValue / (float)this.iAftValue;
					num = Mathf.Clamp01(num);
				}
				return num;
			}
		}

		// Token: 0x04000B83 RID: 2947
		public string title;

		// Token: 0x04000B84 RID: 2948
		public int iPreValue;

		// Token: 0x04000B85 RID: 2949
		public int iAftValue;
	}

	// Token: 0x0200020D RID: 525
	private class OrderMethod
	{
		// Token: 0x060011B1 RID: 4529 RVA: 0x0005DCB8 File Offset: 0x0005C0B8
		public void Invoke()
		{
			for (int i = 0; i < this.datas.Count; i++)
			{
				this.method.Invoke(this.target, new object[]
				{
					this.datas[i]
				});
			}
		}

		// Token: 0x04000B86 RID: 2950
		public MessageHandleAttribute attr;

		// Token: 0x04000B87 RID: 2951
		public List<MsgDATA> datas;

		// Token: 0x04000B88 RID: 2952
		public MethodInfo method;

		// Token: 0x04000B89 RID: 2953
		public object target;
	}

	// Token: 0x0200020E RID: 526
	public enum enDTFormate
	{
		// Token: 0x04000B8B RID: 2955
		FULL,
		// Token: 0x04000B8C RID: 2956
		DATE,
		// Token: 0x04000B8D RID: 2957
		TIME
	}

	// Token: 0x0200020F RID: 527
	public enum NameResult
	{
		// Token: 0x04000B8F RID: 2959
		Vaild,
		// Token: 0x04000B90 RID: 2960
		Null,
		// Token: 0x04000B91 RID: 2961
		OutOfLength,
		// Token: 0x04000B92 RID: 2962
		InVaildChar
	}

	// Token: 0x02000210 RID: 528
	public enum StrengthOperateResult
	{
		// Token: 0x04000B94 RID: 2964
		SOR_HAS_NO_ITEM,
		// Token: 0x04000B95 RID: 2965
		SOR_UNCOLOR,
		// Token: 0x04000B96 RID: 2966
		SOR_COLOR,
		// Token: 0x04000B97 RID: 2967
		SOR_GOLD,
		// Token: 0x04000B98 RID: 2968
		SOR_OK,
		// Token: 0x04000B99 RID: 2969
		SOR_COST_ITEM_NOT_EXIST,
		// Token: 0x04000B9A RID: 2970
		SOR_HAS_NO_PROTECTED,
		// Token: 0x04000B9B RID: 2971
		SOR_Paradoxicalcrystal,
		// Token: 0x04000B9C RID: 2972
		SOR_Has_No_GrowthProtectd,
		// Token: 0x04000B9D RID: 2973
		SOR_Strengthen_Implement
	}
}
