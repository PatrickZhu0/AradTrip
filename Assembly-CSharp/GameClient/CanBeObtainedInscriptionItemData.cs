using System;

namespace GameClient
{
	// Token: 0x02001B59 RID: 7001
	public class CanBeObtainedInscriptionItemData : IComparable<CanBeObtainedInscriptionItemData>
	{
		// Token: 0x0601126D RID: 70253 RVA: 0x004ECBA8 File Offset: 0x004EAFA8
		public int CompareTo(CanBeObtainedInscriptionItemData other)
		{
			if (this.inscriptionItemData.Quality != other.inscriptionItemData.Quality)
			{
				return other.inscriptionItemData.Quality - this.inscriptionItemData.Quality;
			}
			return this.inscriptionItemData.TableID - other.inscriptionItemData.TableID;
		}

		// Token: 0x0400B116 RID: 45334
		public ItemData inscriptionItemData;

		// Token: 0x0400B117 RID: 45335
		public int probability;
	}
}
