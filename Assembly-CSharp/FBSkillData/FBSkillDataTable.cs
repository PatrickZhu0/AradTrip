using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B3E RID: 19262
	public sealed class FBSkillDataTable : Table
	{
		// Token: 0x0601C499 RID: 115865 RVA: 0x0089880A File Offset: 0x00896C0A
		public static FBSkillDataTable GetRootAsFBSkillDataTable(ByteBuffer _bb)
		{
			return FBSkillDataTable.GetRootAsFBSkillDataTable(_bb, new FBSkillDataTable());
		}

		// Token: 0x0601C49A RID: 115866 RVA: 0x00898817 File Offset: 0x00896C17
		public static FBSkillDataTable GetRootAsFBSkillDataTable(ByteBuffer _bb, FBSkillDataTable obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C49B RID: 115867 RVA: 0x00898833 File Offset: 0x00896C33
		public FBSkillDataTable __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170027C6 RID: 10182
		// (get) Token: 0x0601C49C RID: 115868 RVA: 0x00898844 File Offset: 0x00896C44
		public string Path
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170027C7 RID: 10183
		// (get) Token: 0x0601C49D RID: 115869 RVA: 0x00898874 File Offset: 0x00896C74
		public string Type
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x170027C8 RID: 10184
		// (get) Token: 0x0601C49E RID: 115870 RVA: 0x008988A4 File Offset: 0x00896CA4
		public bool IsCommon
		{
			get
			{
				int num = base.__offset(8);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x170027C9 RID: 10185
		// (get) Token: 0x0601C49F RID: 115871 RVA: 0x008988DE File Offset: 0x00896CDE
		public FBSkillData Data
		{
			get
			{
				return this.GetData(new FBSkillData());
			}
		}

		// Token: 0x0601C4A0 RID: 115872 RVA: 0x008988EC File Offset: 0x00896CEC
		public FBSkillData GetData(FBSkillData obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x0601C4A1 RID: 115873 RVA: 0x00898928 File Offset: 0x00896D28
		public static Offset<FBSkillDataTable> CreateFBSkillDataTable(FlatBufferBuilder builder, StringOffset path = default(StringOffset), StringOffset type = default(StringOffset), bool isCommon = false, Offset<FBSkillData> data = default(Offset<FBSkillData>))
		{
			builder.StartObject(4);
			FBSkillDataTable.AddData(builder, data);
			FBSkillDataTable.AddType(builder, type);
			FBSkillDataTable.AddPath(builder, path);
			FBSkillDataTable.AddIsCommon(builder, isCommon);
			return FBSkillDataTable.EndFBSkillDataTable(builder);
		}

		// Token: 0x0601C4A2 RID: 115874 RVA: 0x00898954 File Offset: 0x00896D54
		public static void StartFBSkillDataTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601C4A3 RID: 115875 RVA: 0x0089895D File Offset: 0x00896D5D
		public static void AddPath(FlatBufferBuilder builder, StringOffset pathOffset)
		{
			builder.AddOffset(0, pathOffset.Value, 0);
		}

		// Token: 0x0601C4A4 RID: 115876 RVA: 0x0089896E File Offset: 0x00896D6E
		public static void AddType(FlatBufferBuilder builder, StringOffset typeOffset)
		{
			builder.AddOffset(1, typeOffset.Value, 0);
		}

		// Token: 0x0601C4A5 RID: 115877 RVA: 0x0089897F File Offset: 0x00896D7F
		public static void AddIsCommon(FlatBufferBuilder builder, bool isCommon)
		{
			builder.AddBool(2, isCommon, false);
		}

		// Token: 0x0601C4A6 RID: 115878 RVA: 0x0089898A File Offset: 0x00896D8A
		public static void AddData(FlatBufferBuilder builder, Offset<FBSkillData> dataOffset)
		{
			builder.AddOffset(3, dataOffset.Value, 0);
		}

		// Token: 0x0601C4A7 RID: 115879 RVA: 0x0089899C File Offset: 0x00896D9C
		public static Offset<FBSkillDataTable> EndFBSkillDataTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FBSkillDataTable>(value);
		}
	}
}
