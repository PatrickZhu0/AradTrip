using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005C3 RID: 1475
	public class SkillRecommendTable : IFlatbufferObject
	{
		// Token: 0x1700151D RID: 5405
		// (get) Token: 0x06004D3C RID: 19772 RVA: 0x000F0DB4 File Offset: 0x000EF1B4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004D3D RID: 19773 RVA: 0x000F0DC1 File Offset: 0x000EF1C1
		public static SkillRecommendTable GetRootAsSkillRecommendTable(ByteBuffer _bb)
		{
			return SkillRecommendTable.GetRootAsSkillRecommendTable(_bb, new SkillRecommendTable());
		}

		// Token: 0x06004D3E RID: 19774 RVA: 0x000F0DCE File Offset: 0x000EF1CE
		public static SkillRecommendTable GetRootAsSkillRecommendTable(ByteBuffer _bb, SkillRecommendTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004D3F RID: 19775 RVA: 0x000F0DEA File Offset: 0x000EF1EA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004D40 RID: 19776 RVA: 0x000F0E04 File Offset: 0x000EF204
		public SkillRecommendTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700151E RID: 5406
		// (get) Token: 0x06004D41 RID: 19777 RVA: 0x000F0E10 File Offset: 0x000EF210
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700151F RID: 5407
		// (get) Token: 0x06004D42 RID: 19778 RVA: 0x000F0E5C File Offset: 0x000EF25C
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001520 RID: 5408
		// (get) Token: 0x06004D43 RID: 19779 RVA: 0x000F0EA8 File Offset: 0x000EF2A8
		public int SkillMode
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001521 RID: 5409
		// (get) Token: 0x06004D44 RID: 19780 RVA: 0x000F0EF4 File Offset: 0x000EF2F4
		public int MaxLv
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004D45 RID: 19781 RVA: 0x000F0F40 File Offset: 0x000EF340
		public int SkillIDVecArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001522 RID: 5410
		// (get) Token: 0x06004D46 RID: 19782 RVA: 0x000F0F90 File Offset: 0x000EF390
		public int SkillIDVecLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D47 RID: 19783 RVA: 0x000F0FC3 File Offset: 0x000EF3C3
		public ArraySegment<byte>? GetSkillIDVecBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001523 RID: 5411
		// (get) Token: 0x06004D48 RID: 19784 RVA: 0x000F0FD2 File Offset: 0x000EF3D2
		public FlatBufferArray<int> SkillIDVec
		{
			get
			{
				if (this.SkillIDVecValue == null)
				{
					this.SkillIDVecValue = new FlatBufferArray<int>(new Func<int, int>(this.SkillIDVecArray), this.SkillIDVecLength);
				}
				return this.SkillIDVecValue;
			}
		}

		// Token: 0x06004D49 RID: 19785 RVA: 0x000F1004 File Offset: 0x000EF404
		public int PriorityVecArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001524 RID: 5412
		// (get) Token: 0x06004D4A RID: 19786 RVA: 0x000F1054 File Offset: 0x000EF454
		public int PriorityVecLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D4B RID: 19787 RVA: 0x000F1087 File Offset: 0x000EF487
		public ArraySegment<byte>? GetPriorityVecBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17001525 RID: 5413
		// (get) Token: 0x06004D4C RID: 19788 RVA: 0x000F1096 File Offset: 0x000EF496
		public FlatBufferArray<int> PriorityVec
		{
			get
			{
				if (this.PriorityVecValue == null)
				{
					this.PriorityVecValue = new FlatBufferArray<int>(new Func<int, int>(this.PriorityVecArray), this.PriorityVecLength);
				}
				return this.PriorityVecValue;
			}
		}

		// Token: 0x06004D4D RID: 19789 RVA: 0x000F10C8 File Offset: 0x000EF4C8
		public int PosIDVecArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (1198968983 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001526 RID: 5414
		// (get) Token: 0x06004D4E RID: 19790 RVA: 0x000F1118 File Offset: 0x000EF518
		public int PosIDVecLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004D4F RID: 19791 RVA: 0x000F114B File Offset: 0x000EF54B
		public ArraySegment<byte>? GetPosIDVecBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001527 RID: 5415
		// (get) Token: 0x06004D50 RID: 19792 RVA: 0x000F115A File Offset: 0x000EF55A
		public FlatBufferArray<int> PosIDVec
		{
			get
			{
				if (this.PosIDVecValue == null)
				{
					this.PosIDVecValue = new FlatBufferArray<int>(new Func<int, int>(this.PosIDVecArray), this.PosIDVecLength);
				}
				return this.PosIDVecValue;
			}
		}

		// Token: 0x06004D51 RID: 19793 RVA: 0x000F118C File Offset: 0x000EF58C
		public static Offset<SkillRecommendTable> CreateSkillRecommendTable(FlatBufferBuilder builder, int ID = 0, int JobID = 0, int SkillMode = 0, int MaxLv = 0, VectorOffset SkillIDVecOffset = default(VectorOffset), VectorOffset PriorityVecOffset = default(VectorOffset), VectorOffset PosIDVecOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			SkillRecommendTable.AddPosIDVec(builder, PosIDVecOffset);
			SkillRecommendTable.AddPriorityVec(builder, PriorityVecOffset);
			SkillRecommendTable.AddSkillIDVec(builder, SkillIDVecOffset);
			SkillRecommendTable.AddMaxLv(builder, MaxLv);
			SkillRecommendTable.AddSkillMode(builder, SkillMode);
			SkillRecommendTable.AddJobID(builder, JobID);
			SkillRecommendTable.AddID(builder, ID);
			return SkillRecommendTable.EndSkillRecommendTable(builder);
		}

		// Token: 0x06004D52 RID: 19794 RVA: 0x000F11DB File Offset: 0x000EF5DB
		public static void StartSkillRecommendTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06004D53 RID: 19795 RVA: 0x000F11E4 File Offset: 0x000EF5E4
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004D54 RID: 19796 RVA: 0x000F11EF File Offset: 0x000EF5EF
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(1, JobID, 0);
		}

		// Token: 0x06004D55 RID: 19797 RVA: 0x000F11FA File Offset: 0x000EF5FA
		public static void AddSkillMode(FlatBufferBuilder builder, int SkillMode)
		{
			builder.AddInt(2, SkillMode, 0);
		}

		// Token: 0x06004D56 RID: 19798 RVA: 0x000F1205 File Offset: 0x000EF605
		public static void AddMaxLv(FlatBufferBuilder builder, int MaxLv)
		{
			builder.AddInt(3, MaxLv, 0);
		}

		// Token: 0x06004D57 RID: 19799 RVA: 0x000F1210 File Offset: 0x000EF610
		public static void AddSkillIDVec(FlatBufferBuilder builder, VectorOffset SkillIDVecOffset)
		{
			builder.AddOffset(4, SkillIDVecOffset.Value, 0);
		}

		// Token: 0x06004D58 RID: 19800 RVA: 0x000F1224 File Offset: 0x000EF624
		public static VectorOffset CreateSkillIDVecVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004D59 RID: 19801 RVA: 0x000F1261 File Offset: 0x000EF661
		public static void StartSkillIDVecVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004D5A RID: 19802 RVA: 0x000F126C File Offset: 0x000EF66C
		public static void AddPriorityVec(FlatBufferBuilder builder, VectorOffset PriorityVecOffset)
		{
			builder.AddOffset(5, PriorityVecOffset.Value, 0);
		}

		// Token: 0x06004D5B RID: 19803 RVA: 0x000F1280 File Offset: 0x000EF680
		public static VectorOffset CreatePriorityVecVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004D5C RID: 19804 RVA: 0x000F12BD File Offset: 0x000EF6BD
		public static void StartPriorityVecVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004D5D RID: 19805 RVA: 0x000F12C8 File Offset: 0x000EF6C8
		public static void AddPosIDVec(FlatBufferBuilder builder, VectorOffset PosIDVecOffset)
		{
			builder.AddOffset(6, PosIDVecOffset.Value, 0);
		}

		// Token: 0x06004D5E RID: 19806 RVA: 0x000F12DC File Offset: 0x000EF6DC
		public static VectorOffset CreatePosIDVecVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004D5F RID: 19807 RVA: 0x000F1319 File Offset: 0x000EF719
		public static void StartPosIDVecVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004D60 RID: 19808 RVA: 0x000F1324 File Offset: 0x000EF724
		public static Offset<SkillRecommendTable> EndSkillRecommendTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SkillRecommendTable>(value);
		}

		// Token: 0x06004D61 RID: 19809 RVA: 0x000F133E File Offset: 0x000EF73E
		public static void FinishSkillRecommendTableBuffer(FlatBufferBuilder builder, Offset<SkillRecommendTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B8E RID: 7054
		private Table __p = new Table();

		// Token: 0x04001B8F RID: 7055
		private FlatBufferArray<int> SkillIDVecValue;

		// Token: 0x04001B90 RID: 7056
		private FlatBufferArray<int> PriorityVecValue;

		// Token: 0x04001B91 RID: 7057
		private FlatBufferArray<int> PosIDVecValue;

		// Token: 0x020005C4 RID: 1476
		public enum eCrypt
		{
			// Token: 0x04001B93 RID: 7059
			code = 1198968983
		}
	}
}
