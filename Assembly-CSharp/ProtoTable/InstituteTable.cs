using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004AC RID: 1196
	public class InstituteTable : IFlatbufferObject
	{
		// Token: 0x17000EC5 RID: 3781
		// (get) Token: 0x06003A45 RID: 14917 RVA: 0x000C4268 File Offset: 0x000C2668
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003A46 RID: 14918 RVA: 0x000C4275 File Offset: 0x000C2675
		public static InstituteTable GetRootAsInstituteTable(ByteBuffer _bb)
		{
			return InstituteTable.GetRootAsInstituteTable(_bb, new InstituteTable());
		}

		// Token: 0x06003A47 RID: 14919 RVA: 0x000C4282 File Offset: 0x000C2682
		public static InstituteTable GetRootAsInstituteTable(ByteBuffer _bb, InstituteTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003A48 RID: 14920 RVA: 0x000C429E File Offset: 0x000C269E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003A49 RID: 14921 RVA: 0x000C42B8 File Offset: 0x000C26B8
		public InstituteTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EC6 RID: 3782
		// (get) Token: 0x06003A4A RID: 14922 RVA: 0x000C42C4 File Offset: 0x000C26C4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EC7 RID: 3783
		// (get) Token: 0x06003A4B RID: 14923 RVA: 0x000C4310 File Offset: 0x000C2710
		public int JobID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EC8 RID: 3784
		// (get) Token: 0x06003A4C RID: 14924 RVA: 0x000C435C File Offset: 0x000C275C
		public int DifficultyType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EC9 RID: 3785
		// (get) Token: 0x06003A4D RID: 14925 RVA: 0x000C43A8 File Offset: 0x000C27A8
		public int Type
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000ECA RID: 3786
		// (get) Token: 0x06003A4E RID: 14926 RVA: 0x000C43F4 File Offset: 0x000C27F4
		public string Title
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A4F RID: 14927 RVA: 0x000C4437 File Offset: 0x000C2837
		public ArraySegment<byte>? GetTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000ECB RID: 3787
		// (get) Token: 0x06003A50 RID: 14928 RVA: 0x000C4448 File Offset: 0x000C2848
		public int LevelLimit
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000ECC RID: 3788
		// (get) Token: 0x06003A51 RID: 14929 RVA: 0x000C4494 File Offset: 0x000C2894
		public int MissionID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000ECD RID: 3789
		// (get) Token: 0x06003A52 RID: 14930 RVA: 0x000C44E0 File Offset: 0x000C28E0
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003A53 RID: 14931 RVA: 0x000C452C File Offset: 0x000C292C
		public int BuffIDArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ECE RID: 3790
		// (get) Token: 0x06003A54 RID: 14932 RVA: 0x000C457C File Offset: 0x000C297C
		public int BuffIDLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A55 RID: 14933 RVA: 0x000C45AF File Offset: 0x000C29AF
		public ArraySegment<byte>? GetBuffIDBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000ECF RID: 3791
		// (get) Token: 0x06003A56 RID: 14934 RVA: 0x000C45BE File Offset: 0x000C29BE
		public FlatBufferArray<int> BuffID
		{
			get
			{
				if (this.BuffIDValue == null)
				{
					this.BuffIDValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffIDArray), this.BuffIDLength);
				}
				return this.BuffIDValue;
			}
		}

		// Token: 0x06003A57 RID: 14935 RVA: 0x000C45F0 File Offset: 0x000C29F0
		public int EnemyBuffIDArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ED0 RID: 3792
		// (get) Token: 0x06003A58 RID: 14936 RVA: 0x000C4640 File Offset: 0x000C2A40
		public int EnemyBuffIDLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A59 RID: 14937 RVA: 0x000C4673 File Offset: 0x000C2A73
		public ArraySegment<byte>? GetEnemyBuffIDBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000ED1 RID: 3793
		// (get) Token: 0x06003A5A RID: 14938 RVA: 0x000C4682 File Offset: 0x000C2A82
		public FlatBufferArray<int> EnemyBuffID
		{
			get
			{
				if (this.EnemyBuffIDValue == null)
				{
					this.EnemyBuffIDValue = new FlatBufferArray<int>(new Func<int, int>(this.EnemyBuffIDArray), this.EnemyBuffIDLength);
				}
				return this.EnemyBuffIDValue;
			}
		}

		// Token: 0x06003A5B RID: 14939 RVA: 0x000C46B4 File Offset: 0x000C2AB4
		public int EquipmentIDArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (696711107 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ED2 RID: 3794
		// (get) Token: 0x06003A5C RID: 14940 RVA: 0x000C4704 File Offset: 0x000C2B04
		public int EquipmentIDLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A5D RID: 14941 RVA: 0x000C4737 File Offset: 0x000C2B37
		public ArraySegment<byte>? GetEquipmentIDBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000ED3 RID: 3795
		// (get) Token: 0x06003A5E RID: 14942 RVA: 0x000C4746 File Offset: 0x000C2B46
		public FlatBufferArray<int> EquipmentID
		{
			get
			{
				if (this.EquipmentIDValue == null)
				{
					this.EquipmentIDValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipmentIDArray), this.EquipmentIDLength);
				}
				return this.EquipmentIDValue;
			}
		}

		// Token: 0x17000ED4 RID: 3796
		// (get) Token: 0x06003A5F RID: 14943 RVA: 0x000C4778 File Offset: 0x000C2B78
		public string Resource
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A60 RID: 14944 RVA: 0x000C47BB File Offset: 0x000C2BBB
		public ArraySegment<byte>? GetResourceBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x17000ED5 RID: 3797
		// (get) Token: 0x06003A61 RID: 14945 RVA: 0x000C47CC File Offset: 0x000C2BCC
		public string Tip
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A62 RID: 14946 RVA: 0x000C480F File Offset: 0x000C2C0F
		public ArraySegment<byte>? GetTipBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x06003A63 RID: 14947 RVA: 0x000C4820 File Offset: 0x000C2C20
		public static Offset<InstituteTable> CreateInstituteTable(FlatBufferBuilder builder, int ID = 0, int JobID = 0, int DifficultyType = 0, int Type = 0, StringOffset TitleOffset = default(StringOffset), int LevelLimit = 0, int MissionID = 0, int DungeonID = 0, VectorOffset BuffIDOffset = default(VectorOffset), VectorOffset EnemyBuffIDOffset = default(VectorOffset), VectorOffset EquipmentIDOffset = default(VectorOffset), StringOffset ResourceOffset = default(StringOffset), StringOffset TipOffset = default(StringOffset))
		{
			builder.StartObject(13);
			InstituteTable.AddTip(builder, TipOffset);
			InstituteTable.AddResource(builder, ResourceOffset);
			InstituteTable.AddEquipmentID(builder, EquipmentIDOffset);
			InstituteTable.AddEnemyBuffID(builder, EnemyBuffIDOffset);
			InstituteTable.AddBuffID(builder, BuffIDOffset);
			InstituteTable.AddDungeonID(builder, DungeonID);
			InstituteTable.AddMissionID(builder, MissionID);
			InstituteTable.AddLevelLimit(builder, LevelLimit);
			InstituteTable.AddTitle(builder, TitleOffset);
			InstituteTable.AddType(builder, Type);
			InstituteTable.AddDifficultyType(builder, DifficultyType);
			InstituteTable.AddJobID(builder, JobID);
			InstituteTable.AddID(builder, ID);
			return InstituteTable.EndInstituteTable(builder);
		}

		// Token: 0x06003A64 RID: 14948 RVA: 0x000C48A0 File Offset: 0x000C2CA0
		public static void StartInstituteTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x06003A65 RID: 14949 RVA: 0x000C48AA File Offset: 0x000C2CAA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003A66 RID: 14950 RVA: 0x000C48B5 File Offset: 0x000C2CB5
		public static void AddJobID(FlatBufferBuilder builder, int JobID)
		{
			builder.AddInt(1, JobID, 0);
		}

		// Token: 0x06003A67 RID: 14951 RVA: 0x000C48C0 File Offset: 0x000C2CC0
		public static void AddDifficultyType(FlatBufferBuilder builder, int DifficultyType)
		{
			builder.AddInt(2, DifficultyType, 0);
		}

		// Token: 0x06003A68 RID: 14952 RVA: 0x000C48CB File Offset: 0x000C2CCB
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(3, Type, 0);
		}

		// Token: 0x06003A69 RID: 14953 RVA: 0x000C48D6 File Offset: 0x000C2CD6
		public static void AddTitle(FlatBufferBuilder builder, StringOffset TitleOffset)
		{
			builder.AddOffset(4, TitleOffset.Value, 0);
		}

		// Token: 0x06003A6A RID: 14954 RVA: 0x000C48E7 File Offset: 0x000C2CE7
		public static void AddLevelLimit(FlatBufferBuilder builder, int LevelLimit)
		{
			builder.AddInt(5, LevelLimit, 0);
		}

		// Token: 0x06003A6B RID: 14955 RVA: 0x000C48F2 File Offset: 0x000C2CF2
		public static void AddMissionID(FlatBufferBuilder builder, int MissionID)
		{
			builder.AddInt(6, MissionID, 0);
		}

		// Token: 0x06003A6C RID: 14956 RVA: 0x000C48FD File Offset: 0x000C2CFD
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(7, DungeonID, 0);
		}

		// Token: 0x06003A6D RID: 14957 RVA: 0x000C4908 File Offset: 0x000C2D08
		public static void AddBuffID(FlatBufferBuilder builder, VectorOffset BuffIDOffset)
		{
			builder.AddOffset(8, BuffIDOffset.Value, 0);
		}

		// Token: 0x06003A6E RID: 14958 RVA: 0x000C491C File Offset: 0x000C2D1C
		public static VectorOffset CreateBuffIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A6F RID: 14959 RVA: 0x000C4959 File Offset: 0x000C2D59
		public static void StartBuffIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A70 RID: 14960 RVA: 0x000C4964 File Offset: 0x000C2D64
		public static void AddEnemyBuffID(FlatBufferBuilder builder, VectorOffset EnemyBuffIDOffset)
		{
			builder.AddOffset(9, EnemyBuffIDOffset.Value, 0);
		}

		// Token: 0x06003A71 RID: 14961 RVA: 0x000C4978 File Offset: 0x000C2D78
		public static VectorOffset CreateEnemyBuffIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A72 RID: 14962 RVA: 0x000C49B5 File Offset: 0x000C2DB5
		public static void StartEnemyBuffIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A73 RID: 14963 RVA: 0x000C49C0 File Offset: 0x000C2DC0
		public static void AddEquipmentID(FlatBufferBuilder builder, VectorOffset EquipmentIDOffset)
		{
			builder.AddOffset(10, EquipmentIDOffset.Value, 0);
		}

		// Token: 0x06003A74 RID: 14964 RVA: 0x000C49D4 File Offset: 0x000C2DD4
		public static VectorOffset CreateEquipmentIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003A75 RID: 14965 RVA: 0x000C4A11 File Offset: 0x000C2E11
		public static void StartEquipmentIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003A76 RID: 14966 RVA: 0x000C4A1C File Offset: 0x000C2E1C
		public static void AddResource(FlatBufferBuilder builder, StringOffset ResourceOffset)
		{
			builder.AddOffset(11, ResourceOffset.Value, 0);
		}

		// Token: 0x06003A77 RID: 14967 RVA: 0x000C4A2E File Offset: 0x000C2E2E
		public static void AddTip(FlatBufferBuilder builder, StringOffset TipOffset)
		{
			builder.AddOffset(12, TipOffset.Value, 0);
		}

		// Token: 0x06003A78 RID: 14968 RVA: 0x000C4A40 File Offset: 0x000C2E40
		public static Offset<InstituteTable> EndInstituteTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<InstituteTable>(value);
		}

		// Token: 0x06003A79 RID: 14969 RVA: 0x000C4A5A File Offset: 0x000C2E5A
		public static void FinishInstituteTableBuffer(FlatBufferBuilder builder, Offset<InstituteTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400166E RID: 5742
		private Table __p = new Table();

		// Token: 0x0400166F RID: 5743
		private FlatBufferArray<int> BuffIDValue;

		// Token: 0x04001670 RID: 5744
		private FlatBufferArray<int> EnemyBuffIDValue;

		// Token: 0x04001671 RID: 5745
		private FlatBufferArray<int> EquipmentIDValue;

		// Token: 0x020004AD RID: 1197
		public enum eCrypt
		{
			// Token: 0x04001673 RID: 5747
			code = 696711107
		}
	}
}
