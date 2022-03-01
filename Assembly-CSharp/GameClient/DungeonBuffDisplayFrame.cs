using System;
using System.Collections.Generic;
using System.Text;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010A3 RID: 4259
	public class DungeonBuffDisplayFrame
	{
		// Token: 0x1700199A RID: 6554
		// (get) Token: 0x0600A082 RID: 41090 RVA: 0x002052AC File Offset: 0x002036AC
		public bool IsInited
		{
			get
			{
				return this.isInited;
			}
		}

		// Token: 0x0600A083 RID: 41091 RVA: 0x002052B4 File Offset: 0x002036B4
		public void Init(GameObject root, BeActor player)
		{
			if (root == null)
			{
				return;
			}
			this.mInfoRoot = root;
			this.player = player;
			this.isInited = true;
		}

		// Token: 0x0600A084 RID: 41092 RVA: 0x002052D8 File Offset: 0x002036D8
		public void DeInit()
		{
			this.player = null;
			this.mInfoRoot = null;
			this.isInited = false;
		}

		// Token: 0x0600A085 RID: 41093 RVA: 0x002052F0 File Offset: 0x002036F0
		public void _addBuff(int infoTableId)
		{
			if (this._existBuffUnit(infoTableId))
			{
				return;
			}
			BuffDisplayData buffDisplayData = new BuffDisplayData(infoTableId);
			if (buffDisplayData.TableData == null || buffDisplayData.TableData.IconSortOrder <= -1)
			{
				return;
			}
			HeadInfoMiniIcon buffUnit = new HeadInfoMiniIcon();
			this.mBuffList.Add(buffUnit);
			if (!buffUnit.comBuffIconUnit)
			{
				buffUnit.comBuffIconUnit = ComBuffIconManager.Create(this.mInfoRoot);
			}
			buffUnit.sortOrder = buffDisplayData.TableData.IconSortOrder;
			buffUnit.buffID = infoTableId;
			buffUnit.used = true;
			BeBuff battleBuff = this.player.buffController.HasBuffByID(buffUnit.buffID);
			buffUnit.comBuffIconUnit.BattleBuff = battleBuff;
			if (buffUnit.comBuffIconUnit)
			{
				buffUnit.comBuffIconUnit.Setup(buffDisplayData);
				buffUnit.comBuffIconUnit.SetDurationFormatter(delegate(ComBuffIcon var)
				{
					if (this.player == null || buffUnit.comBuffIconUnit.BattleBuff == null)
					{
						return 1f;
					}
					if (buffUnit.comBuffIconUnit.BattleBuff.duration == -1 || buffUnit.comBuffIconUnit.BattleBuff.duration >= 3600000)
					{
						return 1f;
					}
					return (float)buffUnit.comBuffIconUnit.BattleBuff.GetLeftTime() * 1f / (float)buffUnit.comBuffIconUnit.BattleBuff.duration;
				});
			}
			this.mBuffList.Sort(new Comparison<HeadInfoMiniIcon>(this._Sort));
			this._updateIconUIOrder();
			if (this.updateBuffTipLock)
			{
				this.AddBuffInfoData(buffUnit);
				this.mBuffTip.Sort(new Comparison<BuffInfoTip>(this._SortBuffInfoTip));
			}
		}

		// Token: 0x0600A086 RID: 41094 RVA: 0x0020546C File Offset: 0x0020386C
		public void _removeBuff(int buffId)
		{
			HeadInfoMiniIcon headInfoMiniIcon = this._findBuffUnit(buffId);
			if (headInfoMiniIcon != null)
			{
				ComBuffIconManager.Destroy(headInfoMiniIcon.comBuffIconUnit);
				this.mBuffList.Remove(headInfoMiniIcon);
				headInfoMiniIcon.comBuffIconUnit.gameObject.SetActive(false);
				this.mBuffList.Sort(new Comparison<HeadInfoMiniIcon>(this._Sort));
				this._updateIconUIOrder();
			}
			if (this.updateBuffTipLock)
			{
				BuffInfoTip buffInfoTip = this._findBuffTip(buffId);
				if (buffInfoTip != null)
				{
					this.mBuffTip.Remove(buffInfoTip);
					this.mBuffTip.Sort(new Comparison<BuffInfoTip>(this._SortBuffInfoTip));
				}
			}
		}

		// Token: 0x0600A087 RID: 41095 RVA: 0x0020550C File Offset: 0x0020390C
		public void _updateBuff(float timeElapsed)
		{
			if (!this.IsInited)
			{
				return;
			}
			if (this.player == null)
			{
				return;
			}
			for (int i = 0; i < this.mBuffList.Count; i++)
			{
				if (this.mBuffList[i].sortOrder != -1 && this.mBuffList[i] != null && !(this.mBuffList[i].comBuffIconUnit == null))
				{
					if (this.updateBuffTipLock)
					{
						BeBuff battleBuff = this.mBuffList[i].comBuffIconUnit.BattleBuff;
						if (battleBuff != null)
						{
							this.mBuffTip[i].LeftTime = ((battleBuff.GetLeftTime() != -1 && battleBuff.duration < 3600000) ? BeUtility.Format("{0}{1}", (battleBuff.GetLeftTime() / 1000).ToString(), "秒") : DungeonBuffDisplayFrame.foreverString);
						}
					}
					if (this.mBuffList[i].comBuffIconUnit.gameObject.activeInHierarchy)
					{
						this.mBuffList[i].comBuffIconUnit.MarkCountDirty();
					}
				}
			}
		}

		// Token: 0x0600A088 RID: 41096 RVA: 0x0020565C File Offset: 0x00203A5C
		private bool isResistMagic(int buffid)
		{
			bool result = false;
			for (int i = 0; i < this.ResistMagicBuffID.Length; i++)
			{
				if (buffid == this.ResistMagicBuffID[i])
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600A089 RID: 41097 RVA: 0x0020569A File Offset: 0x00203A9A
		private void AddBuffInfoData(HeadInfoMiniIcon icon)
		{
			if (!this.isResistMagic(icon.buffID))
			{
				this._addBuffInfoData(icon);
			}
			else
			{
				this._addBuffInfoData(icon.buffID);
			}
		}

		// Token: 0x0600A08A RID: 41098 RVA: 0x002056C8 File Offset: 0x00203AC8
		public int GetValidBuffCount()
		{
			int num = 0;
			for (int i = 0; i < this.mBuffList.Count; i++)
			{
				if (!this.mBuffList[i].used)
				{
					break;
				}
				num++;
			}
			return num;
		}

		// Token: 0x0600A08B RID: 41099 RVA: 0x00205718 File Offset: 0x00203B18
		public int GetBuffTipsCount()
		{
			if (this.mBuffTip != null)
			{
				return this.mBuffTip.Count;
			}
			return 0;
		}

		// Token: 0x0600A08C RID: 41100 RVA: 0x00205732 File Offset: 0x00203B32
		public BuffInfoTip GetBuffTipsByIndex(int index)
		{
			if (index >= 0 && index < this.mBuffTip.Count)
			{
				return this.mBuffTip[index];
			}
			return null;
		}

		// Token: 0x0600A08D RID: 41101 RVA: 0x0020575C File Offset: 0x00203B5C
		public void SetBuffTipListUpdate()
		{
			for (int i = 0; i < this.mBuffList.Count; i++)
			{
				this.AddBuffInfoData(this.mBuffList[i]);
			}
			this.updateBuffTipLock = true;
		}

		// Token: 0x0600A08E RID: 41102 RVA: 0x0020579E File Offset: 0x00203B9E
		public void CloseBuffTipListUpdate()
		{
			this.mBuffTip.Clear();
			this.updateBuffTipLock = false;
		}

		// Token: 0x0600A08F RID: 41103 RVA: 0x002057B2 File Offset: 0x00203BB2
		private bool _existBuffUnit(int id)
		{
			return null != this._findBuffUnit(id);
		}

		// Token: 0x0600A090 RID: 41104 RVA: 0x002057C4 File Offset: 0x00203BC4
		private HeadInfoMiniIcon _findBuffUnit(int id)
		{
			for (int i = 0; i < this.mBuffList.Count; i++)
			{
				if (id == this.mBuffList[i].buffID)
				{
					return this.mBuffList[i];
				}
			}
			return null;
		}

		// Token: 0x0600A091 RID: 41105 RVA: 0x00205814 File Offset: 0x00203C14
		private BuffInfoTip _findBuffTip(int id)
		{
			for (int i = 0; i < this.mBuffTip.Count; i++)
			{
				if (id == this.mBuffTip[i].buffID)
				{
					return this.mBuffTip[i];
				}
			}
			return null;
		}

		// Token: 0x0600A092 RID: 41106 RVA: 0x00205864 File Offset: 0x00203C64
		private int _Sort(HeadInfoMiniIcon left, HeadInfoMiniIcon right)
		{
			if (left == null || right == null)
			{
				return 0;
			}
			if (left.sortOrder == right.sortOrder)
			{
				return left.buffID - right.buffID;
			}
			if (left.sortOrder == -1)
			{
				return 1;
			}
			if (right.sortOrder == -1)
			{
				return -1;
			}
			return left.sortOrder - right.sortOrder;
		}

		// Token: 0x0600A093 RID: 41107 RVA: 0x002058CC File Offset: 0x00203CCC
		private int _SortBuffInfoTip(BuffInfoTip left, BuffInfoTip right)
		{
			if (left == null || right == null)
			{
				return 0;
			}
			if (left.sortOrder == right.sortOrder)
			{
				return left.buffID - right.buffID;
			}
			if (left.sortOrder == -1)
			{
				return 1;
			}
			if (right.sortOrder == -1)
			{
				return -1;
			}
			return left.sortOrder - right.sortOrder;
		}

		// Token: 0x0600A094 RID: 41108 RVA: 0x00205934 File Offset: 0x00203D34
		private void _updateIconUIOrder()
		{
			for (int i = 0; i < this.mBuffList.Count; i++)
			{
				if (!this.mBuffList[i].used)
				{
					break;
				}
				if (null != this.mBuffList[i].comBuffIconUnit)
				{
					bool overFlowIconActive = false;
					this.mBuffList[i].comBuffIconUnit.gameObject.transform.SetAsLastSibling();
					if (i == 4)
					{
						overFlowIconActive = true;
					}
					this.mBuffList[i].comBuffIconUnit.SetOverFlowIconActive(overFlowIconActive);
				}
			}
		}

		// Token: 0x0600A095 RID: 41109 RVA: 0x002059D8 File Offset: 0x00203DD8
		private void _addBuffInfoData(HeadInfoMiniIcon unit)
		{
			BeBuff battleBuff = unit.comBuffIconUnit.BattleBuff;
			if (battleBuff != null)
			{
				BuffInfoTip buffInfoTip = new BuffInfoTip
				{
					IconPath = unit.comBuffIconUnit.BuffData.Icon,
					Name = BeUtility.Format(unit.comBuffIconUnit.BuffData.BuffDisName, battleBuff.level),
					LeftTime = string.Empty,
					buffID = unit.buffID,
					sortOrder = unit.sortOrder
				};
				if (buffInfoTip.attriArray == null)
				{
					buffInfoTip.attriArray = new int[this.AttriName.Count];
				}
				this.mBuffTip.Add(buffInfoTip);
				if (battleBuff.buffData.BuffType.Count != 0)
				{
					List<BeMechanism> mechanismList = battleBuff.GetMechanismList();
					if (mechanismList != null)
					{
						for (int i = 0; i < mechanismList.Count; i++)
						{
							Mechanism1017 mechanism = mechanismList[i] as Mechanism1017;
							if (mechanism != null)
							{
								int[] recoverValueArr = mechanism.GetRecoverValueArr();
								for (int j = 0; j < battleBuff.buffData.BuffType.Count; j++)
								{
									switch (battleBuff.buffData.BuffType[j])
									{
									case BuffTable.eBuffType.HP_MAX:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[0];
										break;
									case BuffTable.eBuffType.MP_MAX:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[1];
										break;
									case BuffTable.eBuffType.BASE_ATK:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[4];
										break;
									case BuffTable.eBuffType.BASE_INT:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[5];
										break;
									case BuffTable.eBuffType.ATTACK:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[8];
										break;
									case BuffTable.eBuffType.MAGIC_ATTACK:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[9];
										break;
									case BuffTable.eBuffType.DEFENCE:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[2];
										break;
									case BuffTable.eBuffType.MAGIC_DEFENCE:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[3];
										break;
									case BuffTable.eBuffType.HP_RECOVER:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[10];
										break;
									case BuffTable.eBuffType.MP_RECOVER:
										buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[j]] += recoverValueArr[11];
										break;
									}
								}
							}
						}
					}
					for (int k = 0; k < battleBuff.buffData.BuffType.Count; k++)
					{
						switch (battleBuff.buffData.BuffType[k])
						{
						case BuffTable.eBuffType.HP_MAX:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.maxHp, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.MP_MAX:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.maxMp, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.BASE_ATK:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.baseAtk, battleBuff.level, true) / 1000;
							break;
						case BuffTable.eBuffType.BASE_INT:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.baseInt, battleBuff.level, true) / 1000;
							break;
						case BuffTable.eBuffType.STA:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.sta, battleBuff.level, true) / 1000;
							break;
						case BuffTable.eBuffType.SPR:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.spr, battleBuff.level, true) / 1000;
							break;
						case BuffTable.eBuffType.ATTACK:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.attack, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.MAGIC_ATTACK:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.magicAttack, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.DEFENCE:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.defence, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.MAGIC_DEFENCE:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.magicDefence, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.CIRITICAL_ATTACK:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.ciriticalAttack, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.CIRITICAL_MAGIC_ATTACK:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.ciriticalMagicAttack, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.ATTACK_SPEED:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.attackSpeed, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.SPELL_SPEED:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.spellSpeed, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.MOVE_SPEED:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.moveSpeed, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.DODGE:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.dodge, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.DEX:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.dex, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.HP_RECOVER:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.hpRecover, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.MP_RECOVER:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.mpRecover, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.HARD:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.hard, battleBuff.level, true);
							break;
						case BuffTable.eBuffType.ADD_DAMAGE_PERCENT:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.addDamagePercent, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.ATTACK_ADD_RATE:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.attackAddRate, battleBuff.level, true) / 10;
							break;
						case BuffTable.eBuffType.MAGIC_ATTACK_ADD_RATE:
							buffInfoTip.attriArray[(int)battleBuff.buffData.BuffType[k]] += TableManager.GetValueFromUnionCell(battleBuff.buffData.magicAttackAddRate, battleBuff.level, true) / 10;
							break;
						}
					}
					this._convertAttriData(buffInfoTip);
				}
				else
				{
					if (unit.comBuffIconUnit.BuffData.BuffDescription == "-")
					{
						return;
					}
					buffInfoTip.Detail = unit.comBuffIconUnit.BuffData.BuffDescription;
				}
			}
		}

		// Token: 0x0600A096 RID: 41110 RVA: 0x00206470 File Offset: 0x00204870
		private void _addBuffInfoData(int buffID)
		{
			BuffTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(buffID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			bool flag = false;
			if (this.ResistMagicBuffID != null)
			{
				for (int i = 0; i < this.ResistMagicBuffID.Length; i++)
				{
					if (buffID == this.ResistMagicBuffID[i])
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				BuffInfoTip buffInfoTip = new BuffInfoTip
				{
					IconPath = tableItem.Icon,
					Name = string.Format(tableItem.BuffDisName, 1),
					buffID = buffID,
					LeftTime = DungeonBuffDisplayFrame.foreverString
				};
				this.mBuffTip.Add(buffInfoTip);
				VFactor resistMagicRate = this.player.attribute.GetResistMagicRate();
				int integer = (resistMagicRate * (long)GlobalLogic.VALUE_100).integer;
				string text;
				if (integer >= 0)
				{
					text = BeUtility.Format(DungeonBuffDisplayFrame.resistMagicGreen, integer);
				}
				else
				{
					text = BeUtility.Format(DungeonBuffDisplayFrame.resistMagicRed, integer);
				}
				buffInfoTip.Detail = string.Format(tableItem.Description, text, text);
			}
		}

		// Token: 0x0600A097 RID: 41111 RVA: 0x0020659C File Offset: 0x0020499C
		private void _convertAttriData(BuffInfoTip tip)
		{
			if (tip != null && tip.attriArray != null && tip.attriArray.Length == this.AttriName.Count)
			{
				this.tStringBuilder.Length = 0;
				int num = -1;
				for (int i = 0; i < tip.attriArray.Length; i++)
				{
					int num2 = tip.attriArray[i];
					if (num2 != 0)
					{
						if (num == -1)
						{
							this.AddAttriValue(this.tStringBuilder, "{0}", this.AttriName[i], (float)num2);
							num = i;
						}
						else
						{
							this.AddAttriValue(this.tStringBuilder, " {0}", this.AttriName[i], (float)num2);
						}
					}
				}
				tip.Detail = this.tStringBuilder.ToString();
			}
		}

		// Token: 0x0600A098 RID: 41112 RVA: 0x0020666C File Offset: 0x00204A6C
		private void AddAttriValue(StringBuilder builder, string format, string attriName, float value)
		{
			string empty = string.Empty;
			if (value > 0f)
			{
				empty = DungeonBuffDisplayFrame.greenFormat;
			}
			else if (value < 0f)
			{
				empty = DungeonBuffDisplayFrame.redFormat;
			}
			if (!string.IsNullOrEmpty(empty))
			{
				string arg = BeUtility.Format(empty, value);
				arg = BeUtility.Format(attriName, arg);
				builder.AppendFormat(format, arg);
			}
		}

		// Token: 0x0400592B RID: 22827
		public List<HeadInfoMiniIcon> mBuffList = new List<HeadInfoMiniIcon>();

		// Token: 0x0400592C RID: 22828
		private GameObject mInfoRoot;

		// Token: 0x0400592D RID: 22829
		private BeActor player;

		// Token: 0x0400592E RID: 22830
		private bool updateBuffTipLock;

		// Token: 0x0400592F RID: 22831
		public List<BuffInfoTip> mBuffTip = new List<BuffInfoTip>();

		// Token: 0x04005930 RID: 22832
		private List<string> AttriName = new List<string>(new string[]
		{
			"生命值{0}",
			"魔力值{0}",
			"力量{0}",
			"智力{0}",
			"体力{0}",
			"精神{0}",
			"物理攻击力{0}",
			"魔法攻击力{0}",
			"物理防御{0}",
			"魔法防御{0}",
			"物理暴击{0}%",
			"魔法暴击{0}%",
			"攻击速度{0}%",
			"释放速度{0}%",
			"移动速度{0}%",
			"闪避{0}%",
			"命中{0}%",
			"HP回复{0}",
			"MP回复{0}",
			"硬直{0}",
			"增加伤害{0}%",
			"物理攻击{0}%",
			"魔法攻击{0}%"
		});

		// Token: 0x04005931 RID: 22833
		private bool isInited;

		// Token: 0x04005932 RID: 22834
		private int[] ResistMagicBuffID = new int[]
		{
			820001,
			820002,
			820003
		};

		// Token: 0x04005933 RID: 22835
		private static string resistMagicGreen = "<color=#11EE11> +{0}%</color>";

		// Token: 0x04005934 RID: 22836
		private static string resistMagicRed = "<color=#ff0004ff> {0}%</color>";

		// Token: 0x04005935 RID: 22837
		private static string foreverString = "永久";

		// Token: 0x04005936 RID: 22838
		private StringBuilder tStringBuilder = new StringBuilder(128);

		// Token: 0x04005937 RID: 22839
		private static string greenFormat = "<color=#49DB1A>+{0}</color>";

		// Token: 0x04005938 RID: 22840
		private static string redFormat = "<color=#B8120A>{0}</color>";
	}
}
