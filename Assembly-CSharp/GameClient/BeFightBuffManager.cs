using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001143 RID: 4419
	public class BeFightBuffManager
	{
		// Token: 0x0600A89A RID: 43162 RVA: 0x00238639 File Offset: 0x00236A39
		public List<BeFightBuff> GetBuffList()
		{
			return this.mBuffs;
		}

		// Token: 0x0600A89B RID: 43163 RVA: 0x00238644 File Offset: 0x00236A44
		public void Update(float delta)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (this.mBuffs[i] != null)
				{
					this.mBuffs[i].Update(delta);
				}
			}
		}

		// Token: 0x0600A89C RID: 43164 RVA: 0x00238690 File Offset: 0x00236A90
		public BeFightBuff AddBuff(int id, ulong guid, ulong playerId, float durTime, int overlay)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (this.mBuffs[i].GUID == guid)
				{
					return null;
				}
			}
			BeFightBuff beFightBuff = new BeFightBuff(id, guid, playerId, durTime, overlay);
			this.mBuffs.Add(beFightBuff);
			return beFightBuff;
		}

		// Token: 0x0600A89D RID: 43165 RVA: 0x002386EC File Offset: 0x00236AEC
		public void RemoveBuff(ulong guid)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (this.mBuffs[i].GUID == guid)
				{
					this.mBuffs.RemoveAt(i);
					break;
				}
			}
		}

		// Token: 0x0600A89E RID: 43166 RVA: 0x00238740 File Offset: 0x00236B40
		public bool HasBuff(ulong guid)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (this.mBuffs[i].GUID == guid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A89F RID: 43167 RVA: 0x00238784 File Offset: 0x00236B84
		public BeFightBuff GetBuffByGUID(ulong guid)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (this.mBuffs[i].GUID == guid)
				{
					return this.mBuffs[i];
				}
			}
			return null;
		}

		// Token: 0x0600A8A0 RID: 43168 RVA: 0x002387D4 File Offset: 0x00236BD4
		public bool HasBuffByID(int buffId)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (this.mBuffs[i].BuffID == buffId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A8A1 RID: 43169 RVA: 0x00238817 File Offset: 0x00236C17
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= this.mBuffs.Count)
			{
				return;
			}
			this.mBuffs.RemoveAt(index);
		}

		// Token: 0x0600A8A2 RID: 43170 RVA: 0x0023883E File Offset: 0x00236C3E
		public int Count()
		{
			return this.mBuffs.Count;
		}

		// Token: 0x0600A8A3 RID: 43171 RVA: 0x0023884B File Offset: 0x00236C4B
		public BeFightBuff Get(int index)
		{
			if (index < 0 || index >= this.mBuffs.Count)
			{
				return null;
			}
			return this.mBuffs[index];
		}

		// Token: 0x0600A8A4 RID: 43172 RVA: 0x00238874 File Offset: 0x00236C74
		public void Clear()
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				this.mBuffs[i].DeInit();
			}
			this.mBuffs.Clear();
		}

		// Token: 0x0600A8A5 RID: 43173 RVA: 0x002388BC File Offset: 0x00236CBC
		public void Start(GeActorEx player)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				this.mBuffs[i].Start(player);
			}
		}

		// Token: 0x0600A8A6 RID: 43174 RVA: 0x002388F8 File Offset: 0x00236CF8
		public void Finish(GeActorEx player)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				this.mBuffs[i].Finish(player);
			}
		}

		// Token: 0x04005E30 RID: 24112
		private List<BeFightBuff> mBuffs = new List<BeFightBuff>();
	}
}
