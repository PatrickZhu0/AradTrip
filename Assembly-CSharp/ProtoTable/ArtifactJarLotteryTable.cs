using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002A9 RID: 681
	public class ArtifactJarLotteryTable : IFlatbufferObject
	{
		// Token: 0x17000390 RID: 912
		// (get) Token: 0x0600184A RID: 6218 RVA: 0x00073258 File Offset: 0x00071658
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x00073265 File Offset: 0x00071665
		public static ArtifactJarLotteryTable GetRootAsArtifactJarLotteryTable(ByteBuffer _bb)
		{
			return ArtifactJarLotteryTable.GetRootAsArtifactJarLotteryTable(_bb, new ArtifactJarLotteryTable());
		}

		// Token: 0x0600184C RID: 6220 RVA: 0x00073272 File Offset: 0x00071672
		public static ArtifactJarLotteryTable GetRootAsArtifactJarLotteryTable(ByteBuffer _bb, ArtifactJarLotteryTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600184D RID: 6221 RVA: 0x0007328E File Offset: 0x0007168E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x000732A8 File Offset: 0x000716A8
		public ArtifactJarLotteryTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x0600184F RID: 6223 RVA: 0x000732B4 File Offset: 0x000716B4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1803631640 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06001850 RID: 6224 RVA: 0x00073300 File Offset: 0x00071700
		public int JarId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1803631640 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06001851 RID: 6225 RVA: 0x0007334C File Offset: 0x0007174C
		public int rewardItemId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1803631640 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06001852 RID: 6226 RVA: 0x00073398 File Offset: 0x00071798
		public int rewardItemNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1803631640 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06001853 RID: 6227 RVA: 0x000733E4 File Offset: 0x000717E4
		public int weight
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1803631640 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06001854 RID: 6228 RVA: 0x00073430 File Offset: 0x00071830
		public int limitNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1803631640 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x0007347A File Offset: 0x0007187A
		public static Offset<ArtifactJarLotteryTable> CreateArtifactJarLotteryTable(FlatBufferBuilder builder, int ID = 0, int JarId = 0, int rewardItemId = 0, int rewardItemNum = 0, int weight = 0, int limitNum = 0)
		{
			builder.StartObject(6);
			ArtifactJarLotteryTable.AddLimitNum(builder, limitNum);
			ArtifactJarLotteryTable.AddWeight(builder, weight);
			ArtifactJarLotteryTable.AddRewardItemNum(builder, rewardItemNum);
			ArtifactJarLotteryTable.AddRewardItemId(builder, rewardItemId);
			ArtifactJarLotteryTable.AddJarId(builder, JarId);
			ArtifactJarLotteryTable.AddID(builder, ID);
			return ArtifactJarLotteryTable.EndArtifactJarLotteryTable(builder);
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x000734B6 File Offset: 0x000718B6
		public static void StartArtifactJarLotteryTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06001857 RID: 6231 RVA: 0x000734BF File Offset: 0x000718BF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001858 RID: 6232 RVA: 0x000734CA File Offset: 0x000718CA
		public static void AddJarId(FlatBufferBuilder builder, int JarId)
		{
			builder.AddInt(1, JarId, 0);
		}

		// Token: 0x06001859 RID: 6233 RVA: 0x000734D5 File Offset: 0x000718D5
		public static void AddRewardItemId(FlatBufferBuilder builder, int rewardItemId)
		{
			builder.AddInt(2, rewardItemId, 0);
		}

		// Token: 0x0600185A RID: 6234 RVA: 0x000734E0 File Offset: 0x000718E0
		public static void AddRewardItemNum(FlatBufferBuilder builder, int rewardItemNum)
		{
			builder.AddInt(3, rewardItemNum, 0);
		}

		// Token: 0x0600185B RID: 6235 RVA: 0x000734EB File Offset: 0x000718EB
		public static void AddWeight(FlatBufferBuilder builder, int weight)
		{
			builder.AddInt(4, weight, 0);
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x000734F6 File Offset: 0x000718F6
		public static void AddLimitNum(FlatBufferBuilder builder, int limitNum)
		{
			builder.AddInt(5, limitNum, 0);
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x00073504 File Offset: 0x00071904
		public static Offset<ArtifactJarLotteryTable> EndArtifactJarLotteryTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ArtifactJarLotteryTable>(value);
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x0007351E File Offset: 0x0007191E
		public static void FinishArtifactJarLotteryTableBuffer(FlatBufferBuilder builder, Offset<ArtifactJarLotteryTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DF8 RID: 3576
		private Table __p = new Table();

		// Token: 0x020002AA RID: 682
		public enum eCrypt
		{
			// Token: 0x04000DFA RID: 3578
			code = 1803631640
		}
	}
}
