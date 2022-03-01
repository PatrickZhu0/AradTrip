using System;
using UnityEngine;

// Token: 0x02004B94 RID: 19348
public class DModelData : ScriptableObject
{
	// Token: 0x040138FC RID: 80124
	[NonSerialized]
	public static readonly string[] kPartChannelLabel = new string[]
	{
		"头部部件",
		"上身部件",
		"下身部件",
		"肩膀",
		"翅膀",
		"全身",
		string.Empty
	};

	// Token: 0x040138FD RID: 80125
	public static readonly string[] kPartChannelName = new string[]
	{
		"Head",
		"Body",
		"Pant",
		"Shoulder",
		"Wings",
		string.Empty,
		string.Empty
	};

	// Token: 0x040138FE RID: 80126
	public string modelDataName;

	// Token: 0x040138FF RID: 80127
	public DAssetObject modelAvatar;

	// Token: 0x04013900 RID: 80128
	public Vector3 modelScale = Vector3.one;

	// Token: 0x04013901 RID: 80129
	public Vector3 previewLightDir = Vector3.down;

	// Token: 0x04013902 RID: 80130
	public Color previewAmbient = Color.black;

	// Token: 0x04013903 RID: 80131
	public DModelPartChunk[] partsChunk = new DModelPartChunk[0];

	// Token: 0x04013904 RID: 80132
	public DModelAttachmentChunk attachChunk;

	// Token: 0x04013905 RID: 80133
	public DModelAnimClipChunk animClipChunk;

	// Token: 0x04013906 RID: 80134
	public DAnimatChunk[] animatChunk = new DAnimatChunk[0];

	// Token: 0x04013907 RID: 80135
	public DBlockChunk blockGridChunk;
}
