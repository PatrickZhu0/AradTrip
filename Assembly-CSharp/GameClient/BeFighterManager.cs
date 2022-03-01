using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200113F RID: 4415
	public class BeFighterManager<T> where T : BeBaseFighter
	{
		// Token: 0x0600A87A RID: 43130 RVA: 0x00237AA6 File Offset: 0x00235EA6
		public void AddFighter(ulong guid, T fighter)
		{
			if (this.m_mapFighters.ContainsKey(guid))
			{
				return;
			}
			this.m_Fighters.Add(fighter);
			this.m_mapFighters.Add(guid, fighter);
		}

		// Token: 0x0600A87B RID: 43131 RVA: 0x00237AD3 File Offset: 0x00235ED3
		public void AddFighter(T fighter)
		{
			this.m_Fighters.Add(fighter);
		}

		// Token: 0x0600A87C RID: 43132 RVA: 0x00237AE1 File Offset: 0x00235EE1
		public int GetFightCount()
		{
			return this.m_Fighters.Count;
		}

		// Token: 0x0600A87D RID: 43133 RVA: 0x00237AF0 File Offset: 0x00235EF0
		public T GetFighter(int index)
		{
			if (index < 0 || index >= this.m_Fighters.Count)
			{
				return (T)((object)null);
			}
			if (this.m_Fighters[index] != null)
			{
				T t = this.m_Fighters[index];
				if (!t.IsRemoved)
				{
					return this.m_Fighters[index];
				}
			}
			return (T)((object)null);
		}

		// Token: 0x0600A87E RID: 43134 RVA: 0x00237B64 File Offset: 0x00235F64
		public void Update(float deltaTime)
		{
			bool flag = false;
			for (int i = 0; i < this.m_Fighters.Count; i++)
			{
				T t = this.m_Fighters[i];
				if (!t.IsRemoved)
				{
					t.Update(deltaTime);
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				this.m_Fighters.RemoveAll(delegate(T figher)
				{
					if (figher != null && figher.IsRemoved)
					{
						figher.OnRemove();
						figher.Dispose();
					}
					return figher == null || figher.IsRemoved;
				});
			}
		}

		// Token: 0x0600A87F RID: 43135 RVA: 0x00237BF2 File Offset: 0x00235FF2
		public void Refresh()
		{
			this.m_Fighters.RemoveAll(delegate(T figher)
			{
				if (figher != null && figher.IsRemoved)
				{
					figher.OnRemove();
				}
				return figher == null || figher.IsRemoved;
			});
		}

		// Token: 0x0600A880 RID: 43136 RVA: 0x00237C1D File Offset: 0x0023601D
		public T GetFighter(ulong guid)
		{
			if (this.m_mapFighters.ContainsKey(guid))
			{
				return this.m_mapFighters[guid];
			}
			return (T)((object)null);
		}

		// Token: 0x0600A881 RID: 43137 RVA: 0x00237C44 File Offset: 0x00236044
		public void RemoveFighter(ulong guid)
		{
			if (this.m_mapFighters.ContainsKey(guid))
			{
				T t = this.m_mapFighters[guid];
				t.Remove();
				this.m_mapFighters.Remove(guid);
			}
		}

		// Token: 0x0600A882 RID: 43138 RVA: 0x00237C8C File Offset: 0x0023608C
		public void RemoveFighter(int index)
		{
			if (index < 0 || index >= this.m_Fighters.Count)
			{
				return;
			}
			T t = this.m_Fighters[index];
			if (t != null)
			{
				t.Remove();
				if (this.m_mapFighters.ContainsKey(t.ActorData.GUID))
				{
					this.m_mapFighters.Remove(t.ActorData.GUID);
				}
			}
		}

		// Token: 0x0600A883 RID: 43139 RVA: 0x00237D18 File Offset: 0x00236118
		public void Clear()
		{
			for (int i = 0; i < this.m_Fighters.Count; i++)
			{
				T t = this.m_Fighters[i];
				if (t != null)
				{
					t.Dispose();
					t.Remove();
				}
			}
			this.m_Fighters.Clear();
			this.m_mapFighters.Clear();
		}

		// Token: 0x04005E1F RID: 24095
		private List<T> m_Fighters = new List<T>();

		// Token: 0x04005E20 RID: 24096
		private Dictionary<ulong, T> m_mapFighters = new Dictionary<ulong, T>();
	}
}
