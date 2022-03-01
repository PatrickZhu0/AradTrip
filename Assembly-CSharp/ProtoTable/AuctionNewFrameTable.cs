using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002BE RID: 702
	public class AuctionNewFrameTable : IFlatbufferObject
	{
		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x060018F0 RID: 6384 RVA: 0x0007482C File Offset: 0x00072C2C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060018F1 RID: 6385 RVA: 0x00074839 File Offset: 0x00072C39
		public static AuctionNewFrameTable GetRootAsAuctionNewFrameTable(ByteBuffer _bb)
		{
			return AuctionNewFrameTable.GetRootAsAuctionNewFrameTable(_bb, new AuctionNewFrameTable());
		}

		// Token: 0x060018F2 RID: 6386 RVA: 0x00074846 File Offset: 0x00072C46
		public static AuctionNewFrameTable GetRootAsAuctionNewFrameTable(ByteBuffer _bb, AuctionNewFrameTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060018F3 RID: 6387 RVA: 0x00074862 File Offset: 0x00072C62
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060018F4 RID: 6388 RVA: 0x0007487C File Offset: 0x00072C7C
		public AuctionNewFrameTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x060018F5 RID: 6389 RVA: 0x00074888 File Offset: 0x00072C88
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x060018F6 RID: 6390 RVA: 0x000748D4 File Offset: 0x00072CD4
		public int Layer
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x060018F7 RID: 6391 RVA: 0x00074920 File Offset: 0x00072D20
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060018F8 RID: 6392 RVA: 0x00074962 File Offset: 0x00072D62
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x060018F9 RID: 6393 RVA: 0x00074970 File Offset: 0x00072D70
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x060018FA RID: 6394 RVA: 0x000749BC File Offset: 0x00072DBC
		public AuctionNewFrameTable.eMenuType MenuType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (AuctionNewFrameTable.eMenuType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x00074A00 File Offset: 0x00072E00
		public int LayerRelationArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x060018FC RID: 6396 RVA: 0x00074A50 File Offset: 0x00072E50
		public int LayerRelationLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060018FD RID: 6397 RVA: 0x00074A83 File Offset: 0x00072E83
		public ArraySegment<byte>? GetLayerRelationBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x060018FE RID: 6398 RVA: 0x00074A92 File Offset: 0x00072E92
		public FlatBufferArray<int> LayerRelation
		{
			get
			{
				if (this.LayerRelationValue == null)
				{
					this.LayerRelationValue = new FlatBufferArray<int>(new Func<int, int>(this.LayerRelationArray), this.LayerRelationLength);
				}
				return this.LayerRelationValue;
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x060018FF RID: 6399 RVA: 0x00074AC4 File Offset: 0x00072EC4
		public int PageDisplay
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001900 RID: 6400 RVA: 0x00074B10 File Offset: 0x00072F10
		public int DeleteLayerIDArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06001901 RID: 6401 RVA: 0x00074B60 File Offset: 0x00072F60
		public int DeleteLayerIDLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001902 RID: 6402 RVA: 0x00074B93 File Offset: 0x00072F93
		public ArraySegment<byte>? GetDeleteLayerIDBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06001903 RID: 6403 RVA: 0x00074BA2 File Offset: 0x00072FA2
		public FlatBufferArray<int> DeleteLayerID
		{
			get
			{
				if (this.DeleteLayerIDValue == null)
				{
					this.DeleteLayerIDValue = new FlatBufferArray<int>(new Func<int, int>(this.DeleteLayerIDArray), this.DeleteLayerIDLength);
				}
				return this.DeleteLayerIDValue;
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06001904 RID: 6404 RVA: 0x00074BD4 File Offset: 0x00072FD4
		public AuctionNewFrameTable.eJob Job
		{
			get
			{
				int num = this.__p.__offset(20);
				return (AuctionNewFrameTable.eJob)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06001905 RID: 6405 RVA: 0x00074C18 File Offset: 0x00073018
		public AuctionNewFrameTable.eMainItemType MainItemType
		{
			get
			{
				int num = this.__p.__offset(22);
				return (AuctionNewFrameTable.eMainItemType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001906 RID: 6406 RVA: 0x00074C5C File Offset: 0x0007305C
		public int SubTypeArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06001907 RID: 6407 RVA: 0x00074CAC File Offset: 0x000730AC
		public int SubTypeLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001908 RID: 6408 RVA: 0x00074CDF File Offset: 0x000730DF
		public ArraySegment<byte>? GetSubTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06001909 RID: 6409 RVA: 0x00074CEE File Offset: 0x000730EE
		public FlatBufferArray<int> SubType
		{
			get
			{
				if (this.SubTypeValue == null)
				{
					this.SubTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.SubTypeArray), this.SubTypeLength);
				}
				return this.SubTypeValue;
			}
		}

		// Token: 0x0600190A RID: 6410 RVA: 0x00074D20 File Offset: 0x00073120
		public int ThirdTypeArray(int j)
		{
			int num = this.__p.__offset(26);
			return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x0600190B RID: 6411 RVA: 0x00074D70 File Offset: 0x00073170
		public int ThirdTypeLength
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600190C RID: 6412 RVA: 0x00074DA3 File Offset: 0x000731A3
		public ArraySegment<byte>? GetThirdTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x0600190D RID: 6413 RVA: 0x00074DB2 File Offset: 0x000731B2
		public FlatBufferArray<int> ThirdType
		{
			get
			{
				if (this.ThirdTypeValue == null)
				{
					this.ThirdTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.ThirdTypeArray), this.ThirdTypeLength);
				}
				return this.ThirdTypeValue;
			}
		}

		// Token: 0x0600190E RID: 6414 RVA: 0x00074DE4 File Offset: 0x000731E4
		public AuctionNewFrameTable.eFilterItemType FilterItemTypeArray(int j)
		{
			int num = this.__p.__offset(28);
			return (AuctionNewFrameTable.eFilterItemType)((num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x0600190F RID: 6415 RVA: 0x00074E2C File Offset: 0x0007322C
		public int FilterItemTypeLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001910 RID: 6416 RVA: 0x00074E5F File Offset: 0x0007325F
		public ArraySegment<byte>? GetFilterItemTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06001911 RID: 6417 RVA: 0x00074E6E File Offset: 0x0007326E
		public FlatBufferArray<AuctionNewFrameTable.eFilterItemType> FilterItemType
		{
			get
			{
				if (this.FilterItemTypeValue == null)
				{
					this.FilterItemTypeValue = new FlatBufferArray<AuctionNewFrameTable.eFilterItemType>(new Func<int, AuctionNewFrameTable.eFilterItemType>(this.FilterItemTypeArray), this.FilterItemTypeLength);
				}
				return this.FilterItemTypeValue;
			}
		}

		// Token: 0x06001912 RID: 6418 RVA: 0x00074EA0 File Offset: 0x000732A0
		public int FilterSortTypeArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06001913 RID: 6419 RVA: 0x00074EF0 File Offset: 0x000732F0
		public int FilterSortTypeLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x00074F23 File Offset: 0x00073323
		public ArraySegment<byte>? GetFilterSortTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06001915 RID: 6421 RVA: 0x00074F32 File Offset: 0x00073332
		public FlatBufferArray<int> FilterSortType
		{
			get
			{
				if (this.FilterSortTypeValue == null)
				{
					this.FilterSortTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.FilterSortTypeArray), this.FilterSortTypeLength);
				}
				return this.FilterSortTypeValue;
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06001916 RID: 6422 RVA: 0x00074F64 File Offset: 0x00073364
		public int ChooseLogic
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06001917 RID: 6423 RVA: 0x00074FB0 File Offset: 0x000733B0
		public int JobBaseId
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06001918 RID: 6424 RVA: 0x00074FFC File Offset: 0x000733FC
		public int SpecialParametersType
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06001919 RID: 6425 RVA: 0x00075048 File Offset: 0x00073448
		public int SpecialParameters
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x0600191A RID: 6426 RVA: 0x00075094 File Offset: 0x00073494
		public int IsShow
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (1527745024 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x0600191B RID: 6427 RVA: 0x000750E0 File Offset: 0x000734E0
		public string IconPath
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600191C RID: 6428 RVA: 0x00075123 File Offset: 0x00073523
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x0600191D RID: 6429 RVA: 0x00075134 File Offset: 0x00073534
		public string RecommendedJob
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600191E RID: 6430 RVA: 0x00075177 File Offset: 0x00073577
		public ArraySegment<byte>? GetRecommendedJobBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x0600191F RID: 6431 RVA: 0x00075188 File Offset: 0x00073588
		public string BaseMap
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001920 RID: 6432 RVA: 0x000751CB File Offset: 0x000735CB
		public ArraySegment<byte>? GetBaseMapBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x06001921 RID: 6433 RVA: 0x000751DC File Offset: 0x000735DC
		public static Offset<AuctionNewFrameTable> CreateAuctionNewFrameTable(FlatBufferBuilder builder, int ID = 0, int Layer = 0, StringOffset NameOffset = default(StringOffset), int Sort = 0, AuctionNewFrameTable.eMenuType MenuType = AuctionNewFrameTable.eMenuType.Auction_Menu_None, VectorOffset LayerRelationOffset = default(VectorOffset), int PageDisplay = 0, VectorOffset DeleteLayerIDOffset = default(VectorOffset), AuctionNewFrameTable.eJob Job = AuctionNewFrameTable.eJob.AC_JIANSHI, AuctionNewFrameTable.eMainItemType MainItemType = AuctionNewFrameTable.eMainItemType.MIT_NONE, VectorOffset SubTypeOffset = default(VectorOffset), VectorOffset ThirdTypeOffset = default(VectorOffset), VectorOffset FilterItemTypeOffset = default(VectorOffset), VectorOffset FilterSortTypeOffset = default(VectorOffset), int ChooseLogic = 0, int JobBaseId = 0, int SpecialParametersType = 0, int SpecialParameters = 0, int IsShow = 0, StringOffset IconPathOffset = default(StringOffset), StringOffset RecommendedJobOffset = default(StringOffset), StringOffset BaseMapOffset = default(StringOffset))
		{
			builder.StartObject(22);
			AuctionNewFrameTable.AddBaseMap(builder, BaseMapOffset);
			AuctionNewFrameTable.AddRecommendedJob(builder, RecommendedJobOffset);
			AuctionNewFrameTable.AddIconPath(builder, IconPathOffset);
			AuctionNewFrameTable.AddIsShow(builder, IsShow);
			AuctionNewFrameTable.AddSpecialParameters(builder, SpecialParameters);
			AuctionNewFrameTable.AddSpecialParametersType(builder, SpecialParametersType);
			AuctionNewFrameTable.AddJobBaseId(builder, JobBaseId);
			AuctionNewFrameTable.AddChooseLogic(builder, ChooseLogic);
			AuctionNewFrameTable.AddFilterSortType(builder, FilterSortTypeOffset);
			AuctionNewFrameTable.AddFilterItemType(builder, FilterItemTypeOffset);
			AuctionNewFrameTable.AddThirdType(builder, ThirdTypeOffset);
			AuctionNewFrameTable.AddSubType(builder, SubTypeOffset);
			AuctionNewFrameTable.AddMainItemType(builder, MainItemType);
			AuctionNewFrameTable.AddJob(builder, Job);
			AuctionNewFrameTable.AddDeleteLayerID(builder, DeleteLayerIDOffset);
			AuctionNewFrameTable.AddPageDisplay(builder, PageDisplay);
			AuctionNewFrameTable.AddLayerRelation(builder, LayerRelationOffset);
			AuctionNewFrameTable.AddMenuType(builder, MenuType);
			AuctionNewFrameTable.AddSort(builder, Sort);
			AuctionNewFrameTable.AddName(builder, NameOffset);
			AuctionNewFrameTable.AddLayer(builder, Layer);
			AuctionNewFrameTable.AddID(builder, ID);
			return AuctionNewFrameTable.EndAuctionNewFrameTable(builder);
		}

		// Token: 0x06001922 RID: 6434 RVA: 0x000752A4 File Offset: 0x000736A4
		public static void StartAuctionNewFrameTable(FlatBufferBuilder builder)
		{
			builder.StartObject(22);
		}

		// Token: 0x06001923 RID: 6435 RVA: 0x000752AE File Offset: 0x000736AE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001924 RID: 6436 RVA: 0x000752B9 File Offset: 0x000736B9
		public static void AddLayer(FlatBufferBuilder builder, int Layer)
		{
			builder.AddInt(1, Layer, 0);
		}

		// Token: 0x06001925 RID: 6437 RVA: 0x000752C4 File Offset: 0x000736C4
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06001926 RID: 6438 RVA: 0x000752D5 File Offset: 0x000736D5
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(3, Sort, 0);
		}

		// Token: 0x06001927 RID: 6439 RVA: 0x000752E0 File Offset: 0x000736E0
		public static void AddMenuType(FlatBufferBuilder builder, AuctionNewFrameTable.eMenuType MenuType)
		{
			builder.AddInt(4, (int)MenuType, 0);
		}

		// Token: 0x06001928 RID: 6440 RVA: 0x000752EB File Offset: 0x000736EB
		public static void AddLayerRelation(FlatBufferBuilder builder, VectorOffset LayerRelationOffset)
		{
			builder.AddOffset(5, LayerRelationOffset.Value, 0);
		}

		// Token: 0x06001929 RID: 6441 RVA: 0x000752FC File Offset: 0x000736FC
		public static VectorOffset CreateLayerRelationVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600192A RID: 6442 RVA: 0x00075339 File Offset: 0x00073739
		public static void StartLayerRelationVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600192B RID: 6443 RVA: 0x00075344 File Offset: 0x00073744
		public static void AddPageDisplay(FlatBufferBuilder builder, int PageDisplay)
		{
			builder.AddInt(6, PageDisplay, 0);
		}

		// Token: 0x0600192C RID: 6444 RVA: 0x0007534F File Offset: 0x0007374F
		public static void AddDeleteLayerID(FlatBufferBuilder builder, VectorOffset DeleteLayerIDOffset)
		{
			builder.AddOffset(7, DeleteLayerIDOffset.Value, 0);
		}

		// Token: 0x0600192D RID: 6445 RVA: 0x00075360 File Offset: 0x00073760
		public static VectorOffset CreateDeleteLayerIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600192E RID: 6446 RVA: 0x0007539D File Offset: 0x0007379D
		public static void StartDeleteLayerIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600192F RID: 6447 RVA: 0x000753A8 File Offset: 0x000737A8
		public static void AddJob(FlatBufferBuilder builder, AuctionNewFrameTable.eJob Job)
		{
			builder.AddInt(8, (int)Job, 0);
		}

		// Token: 0x06001930 RID: 6448 RVA: 0x000753B3 File Offset: 0x000737B3
		public static void AddMainItemType(FlatBufferBuilder builder, AuctionNewFrameTable.eMainItemType MainItemType)
		{
			builder.AddInt(9, (int)MainItemType, 0);
		}

		// Token: 0x06001931 RID: 6449 RVA: 0x000753BF File Offset: 0x000737BF
		public static void AddSubType(FlatBufferBuilder builder, VectorOffset SubTypeOffset)
		{
			builder.AddOffset(10, SubTypeOffset.Value, 0);
		}

		// Token: 0x06001932 RID: 6450 RVA: 0x000753D4 File Offset: 0x000737D4
		public static VectorOffset CreateSubTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001933 RID: 6451 RVA: 0x00075411 File Offset: 0x00073811
		public static void StartSubTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001934 RID: 6452 RVA: 0x0007541C File Offset: 0x0007381C
		public static void AddThirdType(FlatBufferBuilder builder, VectorOffset ThirdTypeOffset)
		{
			builder.AddOffset(11, ThirdTypeOffset.Value, 0);
		}

		// Token: 0x06001935 RID: 6453 RVA: 0x00075430 File Offset: 0x00073830
		public static VectorOffset CreateThirdTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001936 RID: 6454 RVA: 0x0007546D File Offset: 0x0007386D
		public static void StartThirdTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001937 RID: 6455 RVA: 0x00075478 File Offset: 0x00073878
		public static void AddFilterItemType(FlatBufferBuilder builder, VectorOffset FilterItemTypeOffset)
		{
			builder.AddOffset(12, FilterItemTypeOffset.Value, 0);
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x0007548C File Offset: 0x0007388C
		public static VectorOffset CreateFilterItemTypeVector(FlatBufferBuilder builder, AuctionNewFrameTable.eFilterItemType[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt((int)data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001939 RID: 6457 RVA: 0x000754C9 File Offset: 0x000738C9
		public static void StartFilterItemTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600193A RID: 6458 RVA: 0x000754D4 File Offset: 0x000738D4
		public static void AddFilterSortType(FlatBufferBuilder builder, VectorOffset FilterSortTypeOffset)
		{
			builder.AddOffset(13, FilterSortTypeOffset.Value, 0);
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x000754E8 File Offset: 0x000738E8
		public static VectorOffset CreateFilterSortTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600193C RID: 6460 RVA: 0x00075525 File Offset: 0x00073925
		public static void StartFilterSortTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600193D RID: 6461 RVA: 0x00075530 File Offset: 0x00073930
		public static void AddChooseLogic(FlatBufferBuilder builder, int ChooseLogic)
		{
			builder.AddInt(14, ChooseLogic, 0);
		}

		// Token: 0x0600193E RID: 6462 RVA: 0x0007553C File Offset: 0x0007393C
		public static void AddJobBaseId(FlatBufferBuilder builder, int JobBaseId)
		{
			builder.AddInt(15, JobBaseId, 0);
		}

		// Token: 0x0600193F RID: 6463 RVA: 0x00075548 File Offset: 0x00073948
		public static void AddSpecialParametersType(FlatBufferBuilder builder, int SpecialParametersType)
		{
			builder.AddInt(16, SpecialParametersType, 0);
		}

		// Token: 0x06001940 RID: 6464 RVA: 0x00075554 File Offset: 0x00073954
		public static void AddSpecialParameters(FlatBufferBuilder builder, int SpecialParameters)
		{
			builder.AddInt(17, SpecialParameters, 0);
		}

		// Token: 0x06001941 RID: 6465 RVA: 0x00075560 File Offset: 0x00073960
		public static void AddIsShow(FlatBufferBuilder builder, int IsShow)
		{
			builder.AddInt(18, IsShow, 0);
		}

		// Token: 0x06001942 RID: 6466 RVA: 0x0007556C File Offset: 0x0007396C
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset IconPathOffset)
		{
			builder.AddOffset(19, IconPathOffset.Value, 0);
		}

		// Token: 0x06001943 RID: 6467 RVA: 0x0007557E File Offset: 0x0007397E
		public static void AddRecommendedJob(FlatBufferBuilder builder, StringOffset RecommendedJobOffset)
		{
			builder.AddOffset(20, RecommendedJobOffset.Value, 0);
		}

		// Token: 0x06001944 RID: 6468 RVA: 0x00075590 File Offset: 0x00073990
		public static void AddBaseMap(FlatBufferBuilder builder, StringOffset BaseMapOffset)
		{
			builder.AddOffset(21, BaseMapOffset.Value, 0);
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x000755A4 File Offset: 0x000739A4
		public static Offset<AuctionNewFrameTable> EndAuctionNewFrameTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionNewFrameTable>(value);
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x000755BE File Offset: 0x000739BE
		public static void FinishAuctionNewFrameTableBuffer(FlatBufferBuilder builder, Offset<AuctionNewFrameTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E60 RID: 3680
		private Table __p = new Table();

		// Token: 0x04000E61 RID: 3681
		private FlatBufferArray<int> LayerRelationValue;

		// Token: 0x04000E62 RID: 3682
		private FlatBufferArray<int> DeleteLayerIDValue;

		// Token: 0x04000E63 RID: 3683
		private FlatBufferArray<int> SubTypeValue;

		// Token: 0x04000E64 RID: 3684
		private FlatBufferArray<int> ThirdTypeValue;

		// Token: 0x04000E65 RID: 3685
		private FlatBufferArray<AuctionNewFrameTable.eFilterItemType> FilterItemTypeValue;

		// Token: 0x04000E66 RID: 3686
		private FlatBufferArray<int> FilterSortTypeValue;

		// Token: 0x020002BF RID: 703
		public enum eMenuType
		{
			// Token: 0x04000E68 RID: 3688
			Auction_Menu_None,
			// Token: 0x04000E69 RID: 3689
			Auction_Menu_Notice
		}

		// Token: 0x020002C0 RID: 704
		public enum eJob
		{
			// Token: 0x04000E6B RID: 3691
			AC_JIANSHI,
			// Token: 0x04000E6C RID: 3692
			AC_QIANGSHOU,
			// Token: 0x04000E6D RID: 3693
			AC_FASHI,
			// Token: 0x04000E6E RID: 3694
			AC_GEDOU,
			// Token: 0x04000E6F RID: 3695
			AC_SHENGZHIZHE,
			// Token: 0x04000E70 RID: 3696
			AC_JOB_ALL = 100
		}

		// Token: 0x020002C1 RID: 705
		public enum eMainItemType
		{
			// Token: 0x04000E72 RID: 3698
			MIT_NONE,
			// Token: 0x04000E73 RID: 3699
			MIT_WEAPON,
			// Token: 0x04000E74 RID: 3700
			MIT_ARMOR,
			// Token: 0x04000E75 RID: 3701
			MIT_JEWELRY,
			// Token: 0x04000E76 RID: 3702
			MIT_COST,
			// Token: 0x04000E77 RID: 3703
			MIT_MATERIAL,
			// Token: 0x04000E78 RID: 3704
			MIT_SPECIAL
		}

		// Token: 0x020002C2 RID: 706
		public enum eFilterItemType
		{
			// Token: 0x04000E7A RID: 3706
			FIT_NONE,
			// Token: 0x04000E7B RID: 3707
			FIT_QUALITY,
			// Token: 0x04000E7C RID: 3708
			FIT_LEVEL,
			// Token: 0x04000E7D RID: 3709
			FIT_SUCCEEDRAT,
			// Token: 0x04000E7E RID: 3710
			FIT_PRICE,
			// Token: 0x04000E7F RID: 3711
			FIT_JOB,
			// Token: 0x04000E80 RID: 3712
			FIT_POSITION,
			// Token: 0x04000E81 RID: 3713
			FIT_MAX = 10
		}

		// Token: 0x020002C3 RID: 707
		public enum eCrypt
		{
			// Token: 0x04000E83 RID: 3715
			code = 1527745024
		}
	}
}
