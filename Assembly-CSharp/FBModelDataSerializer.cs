using System;
using System.IO;
using FBModelData;
using FlatBuffers;
using ProtoTable;
using UnityEngine;

// Token: 0x02000D67 RID: 3431
public class FBModelDataSerializer
{
	// Token: 0x06008B77 RID: 35703 RVA: 0x00199BAE File Offset: 0x00197FAE
	private static StringOffset ToFBString(FlatBufferBuilder builder, string value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return builder.CreateString(value);
		}
		return builder.CreateString(string.Empty);
	}

	// Token: 0x06008B78 RID: 35704 RVA: 0x00199BD0 File Offset: 0x00197FD0
	public static void SaveFBModelData(string FBDataPath, global::DModelData dataObj)
	{
		FlatBufferBuilder flatBufferBuilder = new FlatBufferBuilder(1);
		StringOffset modelDataNameOffset = FBModelDataSerializer.ToFBString(flatBufferBuilder, dataObj.modelDataName);
		StringOffset modelAvatarOffset = FBModelDataSerializer.ToFBString(flatBufferBuilder, dataObj.modelAvatar.m_AssetPath);
		VectorOffset partsChunkOffset = default(VectorOffset);
		if (dataObj.partsChunk.Length > 0)
		{
			StringOffset[] array = new StringOffset[dataObj.partsChunk.Length];
			Offset<FBModelData.DModelPartChunk>[] array2 = new Offset<FBModelData.DModelPartChunk>[dataObj.partsChunk.Length];
			int i = 0;
			int num = dataObj.partsChunk.Length;
			while (i < num)
			{
				global::DModelPartChunk dmodelPartChunk = dataObj.partsChunk[i];
				array[i] = FBModelDataSerializer.ToFBString(flatBufferBuilder, dmodelPartChunk.partAsset.m_AssetPath);
				i++;
			}
			int j = 0;
			int num2 = dataObj.partsChunk.Length;
			while (j < num2)
			{
				global::DModelPartChunk dmodelPartChunk2 = dataObj.partsChunk[j];
				array2[j] = FBModelData.DModelPartChunk.CreateDModelPartChunk(flatBufferBuilder, array[j], (int)dmodelPartChunk2.partChannel);
				j++;
			}
			partsChunkOffset = FBModelData.DModelData.CreatePartsChunkVector(flatBufferBuilder, array2);
		}
		StringOffset[] array3 = new StringOffset[0];
		if (dataObj.attachChunk.attachments != null && dataObj.attachChunk.attachments.Length > 0)
		{
			array3 = new StringOffset[dataObj.attachChunk.attachments.Length];
			int k = 0;
			int num3 = dataObj.attachChunk.attachments.Length;
			while (k < num3)
			{
				global::DModelAttachment dmodelAttachment = dataObj.attachChunk.attachments[k];
				array3[k] = FBModelDataSerializer.ToFBString(flatBufferBuilder, dmodelAttachment.attahcmentAsset.m_AssetPath);
				k++;
			}
		}
		VectorOffset animatChunkOffset = default(VectorOffset);
		if (dataObj.animatChunk != null && dataObj.animatChunk.Length > 0)
		{
			Offset<FBModelData.DAnimatChunk>[] array4 = new Offset<FBModelData.DAnimatChunk>[dataObj.animatChunk.Length];
			int l = 0;
			int num4 = dataObj.animatChunk.Length;
			while (l < num4)
			{
				global::DAnimatChunk danimatChunk = dataObj.animatChunk[l];
				VectorOffset paramDesc = default(VectorOffset);
				if (danimatChunk.paramDesc != null && danimatChunk.paramDesc.Length > 0)
				{
					Offset<FBModelData.DAnimatParamDesc>[] array5 = new Offset<FBModelData.DAnimatParamDesc>[danimatChunk.paramDesc.Length];
					int m = 0;
					int num5 = danimatChunk.paramDesc.Length;
					while (m < num5)
					{
						global::DAnimatParamDesc danimatParamDesc = danimatChunk.paramDesc[m];
						Offset<FBModelData.DAnimatParamObj> paramObj = FBModelData.DAnimatParamObj.CreateDAnimatParamObj(flatBufferBuilder, FBModelDataSerializer.ToFBString(flatBufferBuilder, danimatParamDesc.paramObj._texAsset.m_AssetPath));
						float @float = 0f;
						Color color = Color.white;
						Vector4 vector = Vector4.zero;
						switch (danimatParamDesc.paramType)
						{
						case AnimatParamType.Color:
							color = danimatParamDesc.paramData._color;
							break;
						case AnimatParamType.Vector:
							vector = danimatParamDesc.paramData._vec4;
							break;
						case AnimatParamType.Float:
							@float = danimatParamDesc.paramData._float;
							break;
						}
						FBModelData.DAnimatParamData.StartDAnimatParamData(flatBufferBuilder);
						FBModelData.DAnimatParamData.Add_float(flatBufferBuilder, @float);
						FBModelData.DAnimatParamData.Add_color(flatBufferBuilder, Color.CreateColor(flatBufferBuilder, color.a, color.b, color.g, color.r));
						FBModelData.DAnimatParamData.Add_vec4(flatBufferBuilder, Vector4.CreateVector4(flatBufferBuilder, vector.x, vector.y, vector.z, vector.w));
						Offset<FBModelData.DAnimatParamData> paramData = FBModelData.DAnimatParamData.EndDAnimatParamData(flatBufferBuilder);
						array5[m] = FBModelData.DAnimatParamDesc.CreateDAnimatParamDesc(flatBufferBuilder, FBModelDataSerializer.ToFBString(flatBufferBuilder, danimatParamDesc.paramName), paramData, paramObj, (int)danimatParamDesc.paramType);
						m++;
					}
					paramDesc = FBModelData.DAnimatChunk.CreateParamDescVector(flatBufferBuilder, array5);
				}
				array4[l] = FBModelData.DAnimatChunk.CreateDAnimatChunk(flatBufferBuilder, FBModelDataSerializer.ToFBString(flatBufferBuilder, danimatChunk.name), FBModelDataSerializer.ToFBString(flatBufferBuilder, danimatChunk.shaderName), paramDesc);
				l++;
			}
			animatChunkOffset = FBModelData.DModelData.CreateAnimatChunkVector(flatBufferBuilder, array4);
		}
		VectorOffset gridBlockDataOffset = default(VectorOffset);
		if (dataObj.blockGridChunk.gridBlockData != null && dataObj.blockGridChunk.gridBlockData.Length > 0)
		{
			gridBlockDataOffset = FBModelData.DBlockChunk.CreateGridBlockDataVector(flatBufferBuilder, dataObj.blockGridChunk.gridBlockData);
		}
		FBModelData.DBlockChunk.StartDBlockChunk(flatBufferBuilder);
		FBModelData.DBlockChunk.AddBoundingBoxMin(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.blockGridChunk.boundingBoxMin.x, dataObj.blockGridChunk.boundingBoxMin.y, dataObj.blockGridChunk.boundingBoxMin.z));
		FBModelData.DBlockChunk.AddBoundingBoxMax(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.blockGridChunk.boundingBoxMax.x, dataObj.blockGridChunk.boundingBoxMax.y, dataObj.blockGridChunk.boundingBoxMax.z));
		FBModelData.DBlockChunk.AddGridHeight(flatBufferBuilder, dataObj.blockGridChunk.gridHeight);
		FBModelData.DBlockChunk.AddGridWidth(flatBufferBuilder, dataObj.blockGridChunk.gridWidth);
		FBModelData.DBlockChunk.AddGridBlockData(flatBufferBuilder, gridBlockDataOffset);
		Offset<FBModelData.DBlockChunk> blockGridChunkOffset = FBModelData.DBlockChunk.EndDBlockChunk(flatBufferBuilder);
		FBModelData.DModelData.StartDModelData(flatBufferBuilder);
		FBModelData.DModelData.AddModelDataName(flatBufferBuilder, modelDataNameOffset);
		FBModelData.DModelData.AddModelAvatar(flatBufferBuilder, modelAvatarOffset);
		FBModelData.DModelData.AddModelScale(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.modelScale.x, dataObj.modelScale.y, dataObj.modelScale.z));
		FBModelData.DModelData.AddPreviewLightDir(flatBufferBuilder, Vector3.CreateVector3(flatBufferBuilder, dataObj.previewLightDir.x, dataObj.previewLightDir.y, dataObj.previewLightDir.z));
		FBModelData.DModelData.AddPreviewAmbient(flatBufferBuilder, Color.CreateColor(flatBufferBuilder, dataObj.previewAmbient.a, dataObj.previewAmbient.b, dataObj.previewAmbient.g, dataObj.previewAmbient.r));
		FBModelData.DModelData.AddPartsChunk(flatBufferBuilder, partsChunkOffset);
		if (dataObj.attachChunk.attachments != null && dataObj.attachChunk.attachments.Length > 0 && array3.Length > 0)
		{
			Offset<FBModelData.DModelAttachment>[] array6 = new Offset<FBModelData.DModelAttachment>[dataObj.attachChunk.attachments.Length];
			int n = 0;
			int num6 = dataObj.attachChunk.attachments.Length;
			while (n < num6)
			{
				global::DModelAttachment dmodelAttachment2 = dataObj.attachChunk.attachments[n];
				array6[n] = FBModelData.DModelAttachment.CreateDModelAttachment(flatBufferBuilder, array3[n]);
				n++;
			}
			VectorOffset attachments = FBModelData.DModelAttachmentChunk.CreateAttachmentsVector(flatBufferBuilder, array6);
			FBModelData.DModelData.AddAttachChunk(flatBufferBuilder, FBModelData.DModelAttachmentChunk.CreateDModelAttachmentChunk(flatBufferBuilder, attachments));
		}
		FBModelData.DModelData.AddAnimatChunk(flatBufferBuilder, animatChunkOffset);
		FBModelData.DModelData.AddBlockGridChunk(flatBufferBuilder, blockGridChunkOffset);
		flatBufferBuilder.Finish(FBModelData.DModelData.EndDModelData(flatBufferBuilder).Value, "MDLD");
		using (MemoryStream memoryStream = new MemoryStream(flatBufferBuilder.DataBuffer.Data, flatBufferBuilder.DataBuffer.Position, flatBufferBuilder.Offset))
		{
			File.WriteAllBytes(FBDataPath, memoryStream.ToArray());
		}
	}

	// Token: 0x06008B79 RID: 35705 RVA: 0x0019A2AC File Offset: 0x001986AC
	public static void LoadFBModelData(string FBDataPath, out global::DModelData modelDataAsset)
	{
		modelDataAsset = null;
		FBDataPath = FBDataPath.ToLower();
		if (!File.Exists(FBDataPath))
		{
			modelDataAsset = null;
			return;
		}
		byte[] buffer = File.ReadAllBytes(FBDataPath);
		modelDataAsset = ScriptableObject.CreateInstance<global::DModelData>();
		if (null != modelDataAsset)
		{
			ByteBuffer bb = new ByteBuffer(buffer);
			FBModelData.DModelData rootAsDModelData = FBModelData.DModelData.GetRootAsDModelData(bb);
			if (rootAsDModelData != null)
			{
				modelDataAsset.modelDataName = rootAsDModelData.ModelDataName;
				modelDataAsset.modelAvatar.m_AssetPath = rootAsDModelData.ModelAvatar;
				modelDataAsset.modelAvatar.m_AssetObj = null;
				modelDataAsset.modelScale = new Vector3(rootAsDModelData.ModelScale.X, rootAsDModelData.ModelScale.Y, rootAsDModelData.ModelScale.Z);
				modelDataAsset.previewLightDir = new Vector3(rootAsDModelData.PreviewLightDir.X, rootAsDModelData.PreviewLightDir.Y, rootAsDModelData.PreviewLightDir.Z);
				modelDataAsset.previewAmbient = new Color(rootAsDModelData.PreviewAmbient.R, rootAsDModelData.PreviewAmbient.G, rootAsDModelData.PreviewAmbient.B, rootAsDModelData.PreviewAmbient.A);
				int partsChunkLength = rootAsDModelData.PartsChunkLength;
				if (partsChunkLength > 0)
				{
					modelDataAsset.partsChunk = new global::DModelPartChunk[partsChunkLength];
					int i = 0;
					int num = partsChunkLength;
					while (i < num)
					{
						FBModelData.DModelPartChunk partsChunk = rootAsDModelData.GetPartsChunk(i);
						modelDataAsset.partsChunk[i].partAsset.m_AssetPath = partsChunk.PartAsset;
						modelDataAsset.partsChunk[i].partAsset.m_AssetObj = null;
						modelDataAsset.partsChunk[i].partChannel = (EModelPartChannel)partsChunk.PartChannel;
						i++;
					}
				}
				else
				{
					modelDataAsset.partsChunk = new global::DModelPartChunk[0];
				}
				if (rootAsDModelData.AttachChunk != null && rootAsDModelData.AttachChunk.AttachmentsLength > 0)
				{
					modelDataAsset.attachChunk.attachments = new global::DModelAttachment[rootAsDModelData.AttachChunk.AttachmentsLength];
					int j = 0;
					int num2 = modelDataAsset.attachChunk.attachments.Length;
					while (j < num2)
					{
						FBModelData.DModelAttachment attachments = rootAsDModelData.AttachChunk.GetAttachments(j);
						modelDataAsset.attachChunk.attachments[j].attahcmentAsset.m_AssetPath = attachments.AttahcmentAsset;
						modelDataAsset.attachChunk.attachments[j].attahcmentAsset.m_AssetObj = null;
						j++;
					}
				}
				else
				{
					modelDataAsset.attachChunk.attachments = new global::DModelAttachment[0];
				}
				if (rootAsDModelData.AnimatChunkLength > 0)
				{
					modelDataAsset.animatChunk = new global::DAnimatChunk[rootAsDModelData.AnimatChunkLength];
					int k = 0;
					int num3 = modelDataAsset.animatChunk.Length;
					while (k < num3)
					{
						FBModelData.DAnimatChunk animatChunk = rootAsDModelData.GetAnimatChunk(k);
						modelDataAsset.animatChunk[k].name = animatChunk.Name;
						modelDataAsset.animatChunk[k].shaderName = animatChunk.ShaderName;
						modelDataAsset.animatChunk[k].paramDesc = new global::DAnimatParamDesc[animatChunk.ParamDescLength];
						int l = 0;
						int paramDescLength = animatChunk.ParamDescLength;
						while (l < paramDescLength)
						{
							FBModelData.DAnimatParamDesc paramDesc = animatChunk.GetParamDesc(l);
							modelDataAsset.animatChunk[k].paramDesc[l].paramType = (AnimatParamType)paramDesc.ParamType;
							switch (modelDataAsset.animatChunk[k].paramDesc[l].paramType)
							{
							case AnimatParamType.Color:
								modelDataAsset.animatChunk[k].paramDesc[l].paramData._color = new Color(paramDesc.ParamData._color.R, paramDesc.ParamData._color.G, paramDesc.ParamData._color.B, paramDesc.ParamData._color.A);
								break;
							case AnimatParamType.Vector:
								modelDataAsset.animatChunk[k].paramDesc[l].paramData._vec4 = new Vector4(paramDesc.ParamData._vec4.X, paramDesc.ParamData._vec4.Y, paramDesc.ParamData._vec4.Z, paramDesc.ParamData._vec4.W);
								break;
							case AnimatParamType.Float:
								modelDataAsset.animatChunk[k].paramDesc[l].paramData._float = paramDesc.ParamData._float;
								break;
							}
							modelDataAsset.animatChunk[k].paramDesc[l].paramObj._texAsset.m_AssetPath = paramDesc.ParamObj._texAsset;
							modelDataAsset.animatChunk[k].paramDesc[l].paramObj._texAsset.m_AssetObj = null;
							modelDataAsset.animatChunk[k].paramDesc[l].paramName = paramDesc.ParamName;
							l++;
						}
						k++;
					}
				}
				else
				{
					modelDataAsset.attachChunk.attachments = new global::DModelAttachment[0];
				}
				modelDataAsset.blockGridChunk.boundingBoxMin = new Vector3(rootAsDModelData.BlockGridChunk.BoundingBoxMin.X, rootAsDModelData.BlockGridChunk.BoundingBoxMin.Y, rootAsDModelData.BlockGridChunk.BoundingBoxMin.Z);
				modelDataAsset.blockGridChunk.boundingBoxMax = new Vector3(rootAsDModelData.BlockGridChunk.BoundingBoxMax.X, rootAsDModelData.BlockGridChunk.BoundingBoxMax.Y, rootAsDModelData.BlockGridChunk.BoundingBoxMax.Z);
				modelDataAsset.blockGridChunk.gridHeight = rootAsDModelData.BlockGridChunk.GridHeight;
				modelDataAsset.blockGridChunk.gridWidth = rootAsDModelData.BlockGridChunk.GridWidth;
				modelDataAsset.blockGridChunk.gridBlockData = new byte[rootAsDModelData.BlockGridChunk.GridBlockDataLength];
				int m = 0;
				int num4 = modelDataAsset.blockGridChunk.gridBlockData.Length;
				while (m < num4)
				{
					modelDataAsset.blockGridChunk.gridBlockData[m] = rootAsDModelData.BlockGridChunk.GetGridBlockData(m);
					m++;
				}
			}
		}
	}

	// Token: 0x06008B7A RID: 35706 RVA: 0x0019A91C File Offset: 0x00198D1C
	public static string GetBlockDataResPath(int resID)
	{
		string result = string.Empty;
		ResTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(resID, string.Empty, string.Empty);
		if (tableItem != null)
		{
			string text = Path.ChangeExtension(tableItem.ModelPath, null).Replace('\\', '/');
			string[] array = text.Split(new char[]
			{
				'/'
			});
			string text2 = array[array.Length - 1];
			int length = text.IndexOf(text2);
			string str = text.Substring(0, length);
			result = str + text2 + "_ModelData";
		}
		return result;
	}

	// Token: 0x06008B7B RID: 35707 RVA: 0x0019A9A4 File Offset: 0x00198DA4
	public static byte[] GetFBBlockData(int resID, out int width, out int height)
	{
		width = 1;
		height = 1;
		string blockDataResPath = FBModelDataSerializer.GetBlockDataResPath(resID);
		if (!string.IsNullOrEmpty(blockDataResPath))
		{
			global::DModelData dmodelData = Singleton<AssetLoader>.instance.LoadRes(blockDataResPath, false, 0U).obj as global::DModelData;
			if (null != dmodelData)
			{
				width = dmodelData.blockGridChunk.gridWidth;
				height = dmodelData.blockGridChunk.gridHeight;
				return dmodelData.blockGridChunk.gridBlockData;
			}
		}
		return FBModelDataSerializer.DEFAULT_BLOCK_DATA;
	}

	// Token: 0x040044B4 RID: 17588
	protected static readonly byte[] DEFAULT_BLOCK_DATA = new byte[]
	{
		1
	};
}
