using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D63 RID: 3427
	public sealed class DAnimatParamDesc : Table
	{
		// Token: 0x06008B18 RID: 35608 RVA: 0x0019910E File Offset: 0x0019750E
		public static DAnimatParamDesc GetRootAsDAnimatParamDesc(ByteBuffer _bb)
		{
			return DAnimatParamDesc.GetRootAsDAnimatParamDesc(_bb, new DAnimatParamDesc());
		}

		// Token: 0x06008B19 RID: 35609 RVA: 0x0019911B File Offset: 0x0019751B
		public static DAnimatParamDesc GetRootAsDAnimatParamDesc(ByteBuffer _bb, DAnimatParamDesc obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008B1A RID: 35610 RVA: 0x00199137 File Offset: 0x00197537
		public DAnimatParamDesc __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17001883 RID: 6275
		// (get) Token: 0x06008B1B RID: 35611 RVA: 0x00199148 File Offset: 0x00197548
		public string ParamName
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x17001884 RID: 6276
		// (get) Token: 0x06008B1C RID: 35612 RVA: 0x00199177 File Offset: 0x00197577
		public DAnimatParamData ParamData
		{
			get
			{
				return this.GetParamData(new DAnimatParamData());
			}
		}

		// Token: 0x06008B1D RID: 35613 RVA: 0x00199184 File Offset: 0x00197584
		public DAnimatParamData GetParamData(DAnimatParamData obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17001885 RID: 6277
		// (get) Token: 0x06008B1E RID: 35614 RVA: 0x001991BF File Offset: 0x001975BF
		public DAnimatParamObj ParamObj
		{
			get
			{
				return this.GetParamObj(new DAnimatParamObj());
			}
		}

		// Token: 0x06008B1F RID: 35615 RVA: 0x001991CC File Offset: 0x001975CC
		public DAnimatParamObj GetParamObj(DAnimatParamObj obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17001886 RID: 6278
		// (get) Token: 0x06008B20 RID: 35616 RVA: 0x00199208 File Offset: 0x00197608
		public int ParamType
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x06008B21 RID: 35617 RVA: 0x0019923D File Offset: 0x0019763D
		public static Offset<DAnimatParamDesc> CreateDAnimatParamDesc(FlatBufferBuilder builder, StringOffset paramName = default(StringOffset), Offset<DAnimatParamData> paramData = default(Offset<DAnimatParamData>), Offset<DAnimatParamObj> paramObj = default(Offset<DAnimatParamObj>), int paramType = 0)
		{
			builder.StartObject(4);
			DAnimatParamDesc.AddParamType(builder, paramType);
			DAnimatParamDesc.AddParamObj(builder, paramObj);
			DAnimatParamDesc.AddParamData(builder, paramData);
			DAnimatParamDesc.AddParamName(builder, paramName);
			return DAnimatParamDesc.EndDAnimatParamDesc(builder);
		}

		// Token: 0x06008B22 RID: 35618 RVA: 0x00199269 File Offset: 0x00197669
		public static void StartDAnimatParamDesc(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06008B23 RID: 35619 RVA: 0x00199272 File Offset: 0x00197672
		public static void AddParamName(FlatBufferBuilder builder, StringOffset paramNameOffset)
		{
			builder.AddOffset(0, paramNameOffset.Value, 0);
		}

		// Token: 0x06008B24 RID: 35620 RVA: 0x00199283 File Offset: 0x00197683
		public static void AddParamData(FlatBufferBuilder builder, Offset<DAnimatParamData> paramDataOffset)
		{
			builder.AddOffset(1, paramDataOffset.Value, 0);
		}

		// Token: 0x06008B25 RID: 35621 RVA: 0x00199294 File Offset: 0x00197694
		public static void AddParamObj(FlatBufferBuilder builder, Offset<DAnimatParamObj> paramObjOffset)
		{
			builder.AddOffset(2, paramObjOffset.Value, 0);
		}

		// Token: 0x06008B26 RID: 35622 RVA: 0x001992A5 File Offset: 0x001976A5
		public static void AddParamType(FlatBufferBuilder builder, int paramType)
		{
			builder.AddInt(3, paramType, 0);
		}

		// Token: 0x06008B27 RID: 35623 RVA: 0x001992B0 File Offset: 0x001976B0
		public static Offset<DAnimatParamDesc> EndDAnimatParamDesc(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DAnimatParamDesc>(value);
		}
	}
}
