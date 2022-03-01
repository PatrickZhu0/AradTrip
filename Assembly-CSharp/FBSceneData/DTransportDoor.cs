using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B13 RID: 19219
	public sealed class DTransportDoor : Table
	{
		// Token: 0x0601BFC6 RID: 114630 RVA: 0x0088E29A File Offset: 0x0088C69A
		public static DTransportDoor GetRootAsDTransportDoor(ByteBuffer _bb)
		{
			return DTransportDoor.GetRootAsDTransportDoor(_bb, new DTransportDoor());
		}

		// Token: 0x0601BFC7 RID: 114631 RVA: 0x0088E2A7 File Offset: 0x0088C6A7
		public static DTransportDoor GetRootAsDTransportDoor(ByteBuffer _bb, DTransportDoor obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BFC8 RID: 114632 RVA: 0x0088E2C3 File Offset: 0x0088C6C3
		public DTransportDoor __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002638 RID: 9784
		// (get) Token: 0x0601BFC9 RID: 114633 RVA: 0x0088E2D4 File Offset: 0x0088C6D4
		public DRegionInfo Super
		{
			get
			{
				return this.GetSuper(new DRegionInfo());
			}
		}

		// Token: 0x0601BFCA RID: 114634 RVA: 0x0088E2E4 File Offset: 0x0088C6E4
		public DRegionInfo GetSuper(DRegionInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17002639 RID: 9785
		// (get) Token: 0x0601BFCB RID: 114635 RVA: 0x0088E320 File Offset: 0x0088C720
		public bool Iseggdoor
		{
			get
			{
				int num = base.__offset(6);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x1700263A RID: 9786
		// (get) Token: 0x0601BFCC RID: 114636 RVA: 0x0088E35C File Offset: 0x0088C75C
		public TransportDoorType Doortype
		{
			get
			{
				int num = base.__offset(8);
				return (TransportDoorType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x1700263B RID: 9787
		// (get) Token: 0x0601BFCD RID: 114637 RVA: 0x0088E390 File Offset: 0x0088C790
		public int Nextsceneid
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700263C RID: 9788
		// (get) Token: 0x0601BFCE RID: 114638 RVA: 0x0088E3C8 File Offset: 0x0088C7C8
		public string Townscenepath
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700263D RID: 9789
		// (get) Token: 0x0601BFCF RID: 114639 RVA: 0x0088E3F8 File Offset: 0x0088C7F8
		public TransportDoorType Nextdoortype
		{
			get
			{
				int num = base.__offset(14);
				return (TransportDoorType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x1700263E RID: 9790
		// (get) Token: 0x0601BFD0 RID: 114640 RVA: 0x0088E42D File Offset: 0x0088C82D
		public Vector3 Birthposition
		{
			get
			{
				return this.GetBirthposition(new Vector3());
			}
		}

		// Token: 0x0601BFD1 RID: 114641 RVA: 0x0088E43C File Offset: 0x0088C83C
		public Vector3 GetBirthposition(Vector3 obj)
		{
			int num = base.__offset(16);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601BFD2 RID: 114642 RVA: 0x0088E472 File Offset: 0x0088C872
		public static void StartDTransportDoor(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0601BFD3 RID: 114643 RVA: 0x0088E47B File Offset: 0x0088C87B
		public static void AddSuper(FlatBufferBuilder builder, Offset<DRegionInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BFD4 RID: 114644 RVA: 0x0088E48C File Offset: 0x0088C88C
		public static void AddIseggdoor(FlatBufferBuilder builder, bool iseggdoor)
		{
			builder.AddBool(1, iseggdoor, false);
		}

		// Token: 0x0601BFD5 RID: 114645 RVA: 0x0088E497 File Offset: 0x0088C897
		public static void AddDoortype(FlatBufferBuilder builder, TransportDoorType doortype)
		{
			builder.AddSbyte(2, (sbyte)doortype, 0);
		}

		// Token: 0x0601BFD6 RID: 114646 RVA: 0x0088E4A2 File Offset: 0x0088C8A2
		public static void AddNextsceneid(FlatBufferBuilder builder, int nextsceneid)
		{
			builder.AddInt(3, nextsceneid, 0);
		}

		// Token: 0x0601BFD7 RID: 114647 RVA: 0x0088E4AD File Offset: 0x0088C8AD
		public static void AddTownscenepath(FlatBufferBuilder builder, StringOffset townscenepathOffset)
		{
			builder.AddOffset(4, townscenepathOffset.Value, 0);
		}

		// Token: 0x0601BFD8 RID: 114648 RVA: 0x0088E4BE File Offset: 0x0088C8BE
		public static void AddNextdoortype(FlatBufferBuilder builder, TransportDoorType nextdoortype)
		{
			builder.AddSbyte(5, (sbyte)nextdoortype, 0);
		}

		// Token: 0x0601BFD9 RID: 114649 RVA: 0x0088E4C9 File Offset: 0x0088C8C9
		public static void AddBirthposition(FlatBufferBuilder builder, Offset<Vector3> birthpositionOffset)
		{
			builder.AddStruct(6, birthpositionOffset.Value, 0);
		}

		// Token: 0x0601BFDA RID: 114650 RVA: 0x0088E4DC File Offset: 0x0088C8DC
		public static Offset<DTransportDoor> EndDTransportDoor(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DTransportDoor>(value);
		}
	}
}
