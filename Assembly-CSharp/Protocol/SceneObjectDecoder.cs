using System;
using System.Collections.Generic;

namespace Protocol
{
	// Token: 0x02000650 RID: 1616
	public class SceneObjectDecoder : StreamObjectDecoder<SceneObject>
	{
		// Token: 0x060055BC RID: 21948 RVA: 0x00106C04 File Offset: 0x00105004
		public static Dictionary<ulong, SceneObject> DecodeSyncSceneObjectMsg(byte[] buffer, ref int pos, int length)
		{
			Dictionary<ulong, SceneObject> dictionary = new Dictionary<ulong, SceneObject>();
			byte b = 0;
			BaseDLL.decode_int8(buffer, ref pos, ref b);
			uint sceneId = 0U;
			BaseDLL.decode_uint32(buffer, ref pos, ref sceneId);
			while (length - pos > 8)
			{
				SceneObject sceneObject = new SceneObject();
				sceneObject.sceneId = sceneId;
				if (!SceneObjectDecoder.DecodeSceneObject(ref sceneObject, buffer, ref pos, length))
				{
					Logger.LogErrorFormat("decode syn scene object msg failed", new object[0]);
					return null;
				}
				dictionary.Add(sceneObject.id, sceneObject);
			}
			return dictionary;
		}

		// Token: 0x060055BD RID: 21949 RVA: 0x00106C7A File Offset: 0x0010507A
		public static bool DecodeSyncSelfObject(ref SceneObject self, byte[] buffer, ref int pos, int length)
		{
			return StreamObjectDecoder<SceneObject>.DecodePropertys(ref self, buffer, ref pos, length);
		}

		// Token: 0x060055BE RID: 21950 RVA: 0x00106C85 File Offset: 0x00105085
		public static bool DecodeSceneObject(ref SceneObject sceneObj, byte[] buffer, ref int pos, int length)
		{
			StreamObjectDecoder<SceneObject>.InitFieldDict();
			if (length - pos < 9)
			{
				return false;
			}
			BaseDLL.decode_uint64(buffer, ref pos, ref sceneObj.id);
			BaseDLL.decode_int8(buffer, ref pos, ref sceneObj.type);
			return StreamObjectDecoder<SceneObject>.DecodePropertys(ref sceneObj, buffer, ref pos, length);
		}

		// Token: 0x060055BF RID: 21951 RVA: 0x00106CC0 File Offset: 0x001050C0
		public static SceneObject DecodeSelfSceneObject(byte[] buffer, ref int pos, int length)
		{
			SceneObject result = new SceneObject();
			StreamObjectDecoder<SceneObject>.DecodePropertys(ref result, buffer, ref pos, length);
			return result;
		}
	}
}
