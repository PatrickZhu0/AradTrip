using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Battle;

namespace Protocol
{
	// Token: 0x02000665 RID: 1637
	public class StreamObjectDecoder<T> where T : StreamObject
	{
		// Token: 0x060055E6 RID: 21990 RVA: 0x00106098 File Offset: 0x00104498
		protected static void InitFieldDict()
		{
			if (StreamObjectDecoder<T>.fieldDict != null)
			{
				return;
			}
			Type typeFromHandle = typeof(T);
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Instance | BindingFlags.Public);
			Dictionary<int, FieldInfo> dictionary = new Dictionary<int, FieldInfo>();
			foreach (FieldInfo fieldInfo in fields)
			{
				object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(SPropertyAttribute), false);
				if (customAttributes.Length > 0)
				{
					SPropertyAttribute spropertyAttribute = customAttributes[0] as SPropertyAttribute;
					dictionary.Add(spropertyAttribute.id, fieldInfo);
				}
			}
			StreamObjectDecoder<T>.fieldDict = dictionary;
		}

		// Token: 0x060055E7 RID: 21991 RVA: 0x00106121 File Offset: 0x00104521
		public static bool DecodePropertys(ref T streamObj, byte[] buffer, ref int pos, int length)
		{
			streamObj.dirtyFields.Clear();
			while (StreamObjectDecoder<T>.DecodeProperty(ref streamObj, buffer, ref pos, length))
			{
			}
			return true;
		}

		// Token: 0x060055E8 RID: 21992 RVA: 0x0010614C File Offset: 0x0010454C
		private static bool DecodeProperty(ref T streamObj, byte[] buffer, ref int pos, int length)
		{
			StreamObjectDecoder<T>.InitFieldDict();
			if (pos >= length)
			{
				return false;
			}
			byte b = 0;
			BaseDLL.decode_int8(buffer, ref pos, ref b);
			if (b == 0)
			{
				return false;
			}
			FieldInfo fieldInfo;
			if (!StreamObjectDecoder<T>.fieldDict.TryGetValue((int)b, out fieldInfo))
			{
				return false;
			}
			object value = new object();
			if (!StreamObjectDecoder<T>.GetPropertyValue(ref value, fieldInfo, buffer, ref pos, length))
			{
				if (!streamObj.GetStructProperty(fieldInfo, buffer, ref pos, length))
				{
					Logger.LogErrorFormat("decode field attr:{0} failed", new object[]
					{
						b
					});
					return false;
				}
			}
			else
			{
				fieldInfo.SetValue(streamObj, value);
			}
			streamObj.dirtyFields.Add((int)b);
			return true;
		}

		// Token: 0x060055E9 RID: 21993 RVA: 0x00106204 File Offset: 0x00104604
		private static bool GetPropertyValue(ref object value, FieldInfo field, byte[] buffer, ref int pos, int length)
		{
			if (field.FieldType == typeof(byte))
			{
				byte b = 0;
				BaseDLL.decode_int8(buffer, ref pos, ref b);
				value = b;
				return true;
			}
			if (field.FieldType == typeof(ushort))
			{
				ushort num = 0;
				BaseDLL.decode_uint16(buffer, ref pos, ref num);
				value = num;
				return true;
			}
			if (field.FieldType == typeof(uint))
			{
				uint num2 = 0U;
				BaseDLL.decode_uint32(buffer, ref pos, ref num2);
				value = num2;
				return true;
			}
			if (field.FieldType == typeof(int))
			{
				int num3 = 0;
				BaseDLL.decode_int32(buffer, ref pos, ref num3);
				value = num3;
				return true;
			}
			if (field.FieldType == typeof(ulong))
			{
				ulong num4 = 0UL;
				BaseDLL.decode_uint64(buffer, ref pos, ref num4);
				value = num4;
				return true;
			}
			if (field.FieldType == typeof(string))
			{
				ushort num5 = 0;
				BaseDLL.decode_uint16(buffer, ref pos, ref num5);
				byte[] array = new byte[(int)num5];
				for (int i = 0; i < (int)num5; i++)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref array[i]);
				}
				string @string = Encoding.UTF8.GetString(array);
				value = @string;
				return true;
			}
			if (field.FieldType == typeof(ObjectPos))
			{
				ObjectPos objectPos = new ObjectPos();
				BaseDLL.decode_uint16(buffer, ref pos, ref objectPos.x);
				BaseDLL.decode_uint16(buffer, ref pos, ref objectPos.y);
				value = objectPos;
				return true;
			}
			if (field.FieldType == typeof(QQVipInfo))
			{
				QQVipInfo qqvipInfo = new QQVipInfo();
				BaseDLL.decode_int8(buffer, ref pos, ref qqvipInfo.flag);
				BaseDLL.decode_int8(buffer, ref pos, ref qqvipInfo.level);
				BaseDLL.decode_int8(buffer, ref pos, ref qqvipInfo.lv3366);
				value = qqvipInfo;
				return true;
			}
			if (field.FieldType == typeof(ScenePosition))
			{
				ScenePosition scenePosition = new ScenePosition();
				scenePosition.decode(buffer, ref pos);
				value = scenePosition;
				return true;
			}
			if (field.FieldType == typeof(SceneDir))
			{
				SceneDir sceneDir = new SceneDir();
				sceneDir.decode(buffer, ref pos);
				value = sceneDir;
				return true;
			}
			if (field.FieldType == typeof(List<Skill>))
			{
				List<Skill> list = new List<Skill>();
				for (;;)
				{
					Skill skill = new Skill();
					BaseDLL.decode_uint16(buffer, ref pos, ref skill.id);
					if (skill.id == 0)
					{
						break;
					}
					BaseDLL.decode_int8(buffer, ref pos, ref skill.level);
					list.Add(skill);
				}
				value = list;
				return true;
			}
			if (field.FieldType == typeof(List<DungeonBuff>))
			{
				List<DungeonBuff> list2 = new List<DungeonBuff>();
				for (;;)
				{
					Buff buff = new Buff();
					BaseDLL.decode_uint32(buffer, ref pos, ref buff.id);
					if (buff.id == 0U)
					{
						break;
					}
					BaseDLL.decode_uint64(buffer, ref pos, ref buff.uid);
					BaseDLL.decode_uint32(buffer, ref pos, ref buff.overlay);
					BaseDLL.decode_uint32(buffer, ref pos, ref buff.duration);
					list2.Add(new DungeonBuff
					{
						uid = buff.uid,
						id = (int)buff.id,
						overlay = (int)buff.overlay,
						duration = buff.duration,
						lefttime = buff.duration
					});
				}
				value = list2;
				return true;
			}
			if (field.FieldType == typeof(SkillBars))
			{
				SkillBars skillBars = new SkillBars();
				skillBars.decode(buffer, ref pos);
				value = skillBars;
				return true;
			}
			if (field.FieldType == typeof(List<ItemCD>))
			{
				List<ItemCD> list3 = new List<ItemCD>();
				for (;;)
				{
					ItemCD itemCD = new ItemCD();
					BaseDLL.decode_int8(buffer, ref pos, ref itemCD.groupid);
					if (itemCD.groupid == 0)
					{
						break;
					}
					BaseDLL.decode_uint32(buffer, ref pos, ref itemCD.endtime);
					BaseDLL.decode_uint32(buffer, ref pos, ref itemCD.maxtime);
					list3.Add(itemCD);
				}
				value = list3;
				return true;
			}
			if (field.FieldType == typeof(List<WarpStoneInfo>))
			{
				List<WarpStoneInfo> list4 = new List<WarpStoneInfo>();
				for (;;)
				{
					WarpStoneInfo warpStoneInfo = new WarpStoneInfo();
					BaseDLL.decode_uint32(buffer, ref pos, ref warpStoneInfo.id);
					if (warpStoneInfo.id == 0U)
					{
						break;
					}
					BaseDLL.decode_int8(buffer, ref pos, ref warpStoneInfo.level);
					BaseDLL.decode_uint32(buffer, ref pos, ref warpStoneInfo.energy);
					list4.Add(warpStoneInfo);
				}
				value = list4;
				return true;
			}
			if (field.FieldType == typeof(FuncMaskProperty))
			{
				FuncMaskProperty funcMaskProperty = new FuncMaskProperty();
				for (uint num6 = 0U; num6 < funcMaskProperty.byteSize; num6 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref funcMaskProperty.flags[(int)((UIntPtr)num6)]);
				}
				value = funcMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(BootMaskProperty))
			{
				BootMaskProperty bootMaskProperty = new BootMaskProperty();
				for (uint num7 = 0U; num7 < bootMaskProperty.byteSize; num7 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref bootMaskProperty.flags[(int)((UIntPtr)num7)]);
				}
				value = bootMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(Dictionary<string, CounterInfo>))
			{
				Dictionary<string, CounterInfo> dictionary = new Dictionary<string, CounterInfo>();
				for (;;)
				{
					byte b2 = 0;
					BaseDLL.decode_int8(buffer, ref pos, ref b2);
					if (b2 == 0)
					{
						break;
					}
					CounterInfo counterInfo = new CounterInfo();
					ushort num8 = 0;
					BaseDLL.decode_uint16(buffer, ref pos, ref num8);
					byte[] array2 = new byte[(int)num8];
					for (int j = 0; j < (int)num8; j++)
					{
						BaseDLL.decode_int8(buffer, ref pos, ref array2[j]);
					}
					counterInfo.name = StringHelper.BytesToString(array2);
					BaseDLL.decode_uint32(buffer, ref pos, ref counterInfo.value);
					dictionary.Add(counterInfo.name, counterInfo);
				}
				value = dictionary;
				return true;
			}
			if (field.FieldType == typeof(PlayerAvatar))
			{
				PlayerAvatar playerAvatar = new PlayerAvatar();
				playerAvatar.decode(buffer, ref pos);
				value = playerAvatar;
				return true;
			}
			if (field.FieldType == typeof(Vip))
			{
				Vip vip = new Vip();
				vip.decode(buffer, ref pos);
				value = vip;
				return true;
			}
			if (field.FieldType == typeof(SceneRetinue))
			{
				SceneRetinue sceneRetinue = new SceneRetinue();
				sceneRetinue.decode(buffer, ref pos);
				value = sceneRetinue;
				return true;
			}
			if (field.FieldType == typeof(ScenePet))
			{
				ScenePet scenePet = new ScenePet();
				scenePet.decode(buffer, ref pos);
				value = scenePet;
				return true;
			}
			if (field.FieldType == typeof(GuildBattleMaskProperty))
			{
				GuildBattleMaskProperty guildBattleMaskProperty = new GuildBattleMaskProperty();
				for (uint num9 = 0U; num9 < guildBattleMaskProperty.byteSize; num9 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref guildBattleMaskProperty.flags[(int)((UIntPtr)num9)]);
				}
				value = guildBattleMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(DailyTaskMaskProperty))
			{
				DailyTaskMaskProperty dailyTaskMaskProperty = new DailyTaskMaskProperty();
				for (uint num10 = 0U; num10 < dailyTaskMaskProperty.byteSize; num10 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref dailyTaskMaskProperty.flags[(int)((UIntPtr)num10)]);
				}
				value = dailyTaskMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(AchievementMaskProperty))
			{
				AchievementMaskProperty achievementMaskProperty = new AchievementMaskProperty();
				for (uint num11 = 0U; num11 < achievementMaskProperty.byteSize; num11 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref achievementMaskProperty.flags[(int)((UIntPtr)num11)]);
				}
				value = achievementMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(MoneyManageMaskProperty))
			{
				MoneyManageMaskProperty moneyManageMaskProperty = new MoneyManageMaskProperty();
				for (uint num12 = 0U; num12 < moneyManageMaskProperty.byteSize; num12 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref moneyManageMaskProperty.flags[(int)((UIntPtr)num12)]);
				}
				value = moneyManageMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(ScoreWarMaskProperty))
			{
				ScoreWarMaskProperty scoreWarMaskProperty = new ScoreWarMaskProperty();
				for (uint num13 = 0U; num13 < scoreWarMaskProperty.byteSize; num13 += 1U)
				{
					BaseDLL.decode_int8(buffer, ref pos, ref scoreWarMaskProperty.flags[(int)((UIntPtr)num13)]);
				}
				value = scoreWarMaskProperty;
				return true;
			}
			if (field.FieldType == typeof(FatigueInfo))
			{
				FatigueInfo fatigueInfo = new FatigueInfo();
				BaseDLL.decode_uint16(buffer, ref pos, ref fatigueInfo.fatigue);
				BaseDLL.decode_uint16(buffer, ref pos, ref fatigueInfo.maxFatigue);
				value = fatigueInfo;
				return true;
			}
			if (field.FieldType == typeof(List<byte>))
			{
				List<byte> list5 = new List<byte>();
				for (;;)
				{
					byte b3 = 0;
					BaseDLL.decode_int8(buffer, ref pos, ref b3);
					if (b3 == 0)
					{
						break;
					}
					list5.Add(b3);
				}
				value = list5;
				return true;
			}
			if (field.FieldType == typeof(List<uint>))
			{
				List<uint> list6 = new List<uint>();
				byte b4 = 0;
				BaseDLL.decode_int8(buffer, ref pos, ref b4);
				for (int k = 0; k < (int)b4; k++)
				{
					uint item = 0U;
					BaseDLL.decode_uint32(buffer, ref pos, ref item);
					list6.Add(item);
				}
				value = list6;
				return true;
			}
			if (field.FieldType == typeof(List<ulong>))
			{
				List<ulong> list7 = new List<ulong>();
				short num14 = 0;
				BaseDLL.decode_int16(buffer, ref pos, ref num14);
				for (int l = 0; l < (int)num14; l++)
				{
					ulong item2 = 0UL;
					BaseDLL.decode_uint64(buffer, ref pos, ref item2);
					list7.Add(item2);
				}
				value = list7;
				return true;
			}
			if (field.FieldType == typeof(PlayerWearedTitleInfo))
			{
				PlayerWearedTitleInfo playerWearedTitleInfo = new PlayerWearedTitleInfo();
				playerWearedTitleInfo.decode(buffer, ref pos);
				value = playerWearedTitleInfo;
				return true;
			}
			if (field.FieldType == typeof(SkillMgr))
			{
				SkillMgr skillMgr = new SkillMgr();
				skillMgr.decode(buffer, ref pos);
				value = skillMgr;
				return true;
			}
			if (field.FieldType == typeof(Sp))
			{
				Sp sp = new Sp();
				sp.decode(buffer, ref pos);
				value = sp;
				return true;
			}
			return false;
		}

		// Token: 0x040021F4 RID: 8692
		protected static Dictionary<int, FieldInfo> fieldDict;
	}
}
