using System;
using System.Reflection;
using System.Text;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02004578 RID: 17784
	internal class FashionAttributeSelectManager : DataManager<FashionAttributeSelectManager>
	{
		// Token: 0x06018CFC RID: 101628 RVA: 0x007C1621 File Offset: 0x007BFA21
		public override void Initialize()
		{
		}

		// Token: 0x06018CFD RID: 101629 RVA: 0x007C1623 File Offset: 0x007BFA23
		public override void Clear()
		{
		}

		// Token: 0x1700206C RID: 8300
		// (get) Token: 0x06018CFE RID: 101630 RVA: 0x007C1628 File Offset: 0x007BFA28
		public int CostItemID
		{
			get
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(195, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.Value;
				}
				return 0;
			}
		}

		// Token: 0x1700206D RID: 8301
		// (get) Token: 0x06018CFF RID: 101631 RVA: 0x007C165D File Offset: 0x007BFA5D
		public ItemTable CostItem
		{
			get
			{
				return Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.CostItemID, string.Empty, string.Empty);
			}
		}

		// Token: 0x06018D00 RID: 101632 RVA: 0x007C167C File Offset: 0x007BFA7C
		public FashionAttributeSelectManager.FashionAttrItemContent GetAttributeItemContent(int iID)
		{
			EquipAttrTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EquipAttrTable>(iID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			if (tableItem.AttachBuffInfoIDs.Count <= 0 || tableItem.AttachBuffInfoIDs[0] == 0)
			{
				Type typeFromHandle = typeof(EquipAttrTable);
				BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty;
				foreach (PropertyInfo propertyInfo in typeFromHandle.GetProperties(bindingAttr))
				{
					if (propertyInfo != null && !string.Equals(propertyInfo.Name, "ID"))
					{
						if (typeof(int) == propertyInfo.PropertyType || typeof(CrypticInt32) == propertyInfo.PropertyType)
						{
							int num = 0;
							if (propertyInfo.PropertyType == typeof(int))
							{
								num = (int)propertyInfo.GetValue(tableItem, null);
							}
							if (typeof(CrypticInt32) == propertyInfo.PropertyType)
							{
								num = (CrypticInt32)propertyInfo.GetValue(tableItem, null);
							}
							if (num != 0)
							{
								for (int j = 0; j < 61; j++)
								{
									EEquipProp eequipProp = (EEquipProp)j;
									PropAttribute enumAttribute = Utility.GetEnumAttribute<EEquipProp, PropAttribute>(eequipProp);
									if (enumAttribute != null && string.Equals(enumAttribute.fieldName, propertyInfo.Name))
									{
										return new FashionAttributeSelectManager.FashionAttrItemContent
										{
											eType = FashionAttributeSelectManager.FashionAttrItemContent.FashionAttrItemContentType.FICT_BASE_ATTR,
											eProp = eequipProp,
											iValue = num
										};
									}
								}
							}
						}
					}
				}
				return null;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(tableItem.AttachBuffInfoIDs[0], string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("attach buffer info is error with bufferinfo id {0}", new object[]
				{
					tableItem.AttachBuffInfoIDs[0]
				});
				return null;
			}
			return new FashionAttributeSelectManager.FashionAttrItemContent
			{
				eType = FashionAttributeSelectManager.FashionAttrItemContent.FashionAttrItemContentType.FICT_BUFFER_ID,
				iValue = tableItem.AttachBuffInfoIDs[0]
			};
		}

		// Token: 0x06018D01 RID: 101633 RVA: 0x007C188C File Offset: 0x007BFC8C
		public string GetAttributesDesc(int iID, string colorKey = "fashion_attribute_color", string inner = "")
		{
			FashionAttributeSelectManager.FashionAttrItemContent attributeItemContent = this.GetAttributeItemContent(iID);
			if (attributeItemContent != null)
			{
				if (attributeItemContent.eType == FashionAttributeSelectManager.FashionAttrItemContent.FashionAttrItemContentType.FICT_BASE_ATTR)
				{
					StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
					MyExtensionMethods.Clear(stringBuilder);
					stringBuilder.AppendFormat("<color={0}>", TR.Value(colorKey));
					stringBuilder.Append(Utility.GetEEquipProDesc(attributeItemContent.eProp, attributeItemContent.iValue, inner));
					stringBuilder.Append("</color>");
					string result = stringBuilder.ToString();
					StringBuilderCache.Release(stringBuilder);
					return result;
				}
				if (attributeItemContent.eType == FashionAttributeSelectManager.FashionAttrItemContent.FashionAttrItemContentType.FICT_BUFFER_ID)
				{
					BuffInfoTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BuffInfoTable>(attributeItemContent.iValue, string.Empty, string.Empty);
					if (tableItem == null || tableItem.Description.Count <= 0)
					{
						return string.Empty;
					}
					StringBuilder stringBuilder2 = StringBuilderCache.Acquire(256);
					MyExtensionMethods.Clear(stringBuilder2);
					stringBuilder2.AppendFormat("<color={0}>", TR.Value(colorKey));
					stringBuilder2.Append(tableItem.Description[0]);
					stringBuilder2.Append("</color>");
					string result2 = stringBuilder2.ToString();
					StringBuilderCache.Release(stringBuilder2);
					return result2;
				}
			}
			return string.Empty;
		}

		// Token: 0x06018D02 RID: 101634 RVA: 0x007C19AC File Offset: 0x007BFDAC
		public void SendFashionAttributeSelect(ulong guid, int selectedId)
		{
			SceneFashionAttributeSelectReq sceneFashionAttributeSelectReq = new SceneFashionAttributeSelectReq();
			sceneFashionAttributeSelectReq.guid = guid;
			sceneFashionAttributeSelectReq.attributeId = selectedId;
			NetManager.Instance().SendCommand<SceneFashionAttributeSelectReq>(ServerType.GATE_SERVER, sceneFashionAttributeSelectReq);
		}

		// Token: 0x02004579 RID: 17785
		public class FashionAttrItemContent
		{
			// Token: 0x04011E05 RID: 73221
			public FashionAttributeSelectManager.FashionAttrItemContent.FashionAttrItemContentType eType;

			// Token: 0x04011E06 RID: 73222
			public EEquipProp eProp;

			// Token: 0x04011E07 RID: 73223
			public int iValue;

			// Token: 0x0200457A RID: 17786
			public enum FashionAttrItemContentType
			{
				// Token: 0x04011E09 RID: 73225
				FICT_INVALID = -1,
				// Token: 0x04011E0A RID: 73226
				FICT_BASE_ATTR,
				// Token: 0x04011E0B RID: 73227
				FICT_BUFFER_ID
			}
		}
	}
}
