using System;
using FlatBuffers;

namespace FBTransportDoorExtraData
{
	// Token: 0x02004B44 RID: 19268
	public sealed class DTransportDoorExtraData : Table
	{
		// Token: 0x0601C4CE RID: 115918 RVA: 0x0089AE95 File Offset: 0x00899295
		public static DTransportDoorExtraData GetRootAsDTransportDoorExtraData(ByteBuffer _bb)
		{
			return DTransportDoorExtraData.GetRootAsDTransportDoorExtraData(_bb, new DTransportDoorExtraData());
		}

		// Token: 0x0601C4CF RID: 115919 RVA: 0x0089AEA2 File Offset: 0x008992A2
		public static DTransportDoorExtraData GetRootAsDTransportDoorExtraData(ByteBuffer _bb, DTransportDoorExtraData obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C4D0 RID: 115920 RVA: 0x0089AEBE File Offset: 0x008992BE
		public static bool DTransportDoorExtraDataBufferHasIdentifier(ByteBuffer _bb)
		{
			return Table.__has_identifier(_bb, "DTra");
		}

		// Token: 0x0601C4D1 RID: 115921 RVA: 0x0089AECB File Offset: 0x008992CB
		public DTransportDoorExtraData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170027D0 RID: 10192
		// (get) Token: 0x0601C4D2 RID: 115922 RVA: 0x0089AEDC File Offset: 0x008992DC
		public Vector3 Top
		{
			get
			{
				return this.GetTop(new Vector3());
			}
		}

		// Token: 0x0601C4D3 RID: 115923 RVA: 0x0089AEEC File Offset: 0x008992EC
		public Vector3 GetTop(Vector3 obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170027D1 RID: 10193
		// (get) Token: 0x0601C4D4 RID: 115924 RVA: 0x0089AF21 File Offset: 0x00899321
		public Vector3 Buttom
		{
			get
			{
				return this.GetButtom(new Vector3());
			}
		}

		// Token: 0x0601C4D5 RID: 115925 RVA: 0x0089AF30 File Offset: 0x00899330
		public Vector3 GetButtom(Vector3 obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170027D2 RID: 10194
		// (get) Token: 0x0601C4D6 RID: 115926 RVA: 0x0089AF65 File Offset: 0x00899365
		public Vector3 Left
		{
			get
			{
				return this.GetLeft(new Vector3());
			}
		}

		// Token: 0x0601C4D7 RID: 115927 RVA: 0x0089AF74 File Offset: 0x00899374
		public Vector3 GetLeft(Vector3 obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x170027D3 RID: 10195
		// (get) Token: 0x0601C4D8 RID: 115928 RVA: 0x0089AFA9 File Offset: 0x008993A9
		public Vector3 Right
		{
			get
			{
				return this.GetRight(new Vector3());
			}
		}

		// Token: 0x0601C4D9 RID: 115929 RVA: 0x0089AFB8 File Offset: 0x008993B8
		public Vector3 GetRight(Vector3 obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601C4DA RID: 115930 RVA: 0x0089AFEE File Offset: 0x008993EE
		public static void StartDTransportDoorExtraData(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601C4DB RID: 115931 RVA: 0x0089AFF7 File Offset: 0x008993F7
		public static void AddTop(FlatBufferBuilder builder, Offset<Vector3> topOffset)
		{
			builder.AddStruct(0, topOffset.Value, 0);
		}

		// Token: 0x0601C4DC RID: 115932 RVA: 0x0089B008 File Offset: 0x00899408
		public static void AddButtom(FlatBufferBuilder builder, Offset<Vector3> buttomOffset)
		{
			builder.AddStruct(1, buttomOffset.Value, 0);
		}

		// Token: 0x0601C4DD RID: 115933 RVA: 0x0089B019 File Offset: 0x00899419
		public static void AddLeft(FlatBufferBuilder builder, Offset<Vector3> leftOffset)
		{
			builder.AddStruct(2, leftOffset.Value, 0);
		}

		// Token: 0x0601C4DE RID: 115934 RVA: 0x0089B02A File Offset: 0x0089942A
		public static void AddRight(FlatBufferBuilder builder, Offset<Vector3> rightOffset)
		{
			builder.AddStruct(3, rightOffset.Value, 0);
		}

		// Token: 0x0601C4DF RID: 115935 RVA: 0x0089B03C File Offset: 0x0089943C
		public static Offset<DTransportDoorExtraData> EndDTransportDoorExtraData(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DTransportDoorExtraData>(value);
		}

		// Token: 0x0601C4E0 RID: 115936 RVA: 0x0089B056 File Offset: 0x00899456
		public static void FinishDTransportDoorExtraDataBuffer(FlatBufferBuilder builder, Offset<DTransportDoorExtraData> offset)
		{
			builder.Finish(offset.Value, "DTra");
		}
	}
}
