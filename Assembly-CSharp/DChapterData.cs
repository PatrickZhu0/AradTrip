using System;
using UnityEngine;

// Token: 0x02004B9C RID: 19356
public class DChapterData : ScriptableObject
{
	// Token: 0x04013922 RID: 80162
	public Vector2 offsetMin = Vector2.zero;

	// Token: 0x04013923 RID: 80163
	public Vector2 offsetMax = Vector2.zero;

	// Token: 0x04013924 RID: 80164
	public string backgroundPath;

	// Token: 0x04013925 RID: 80165
	public string middlegroudnPath;

	// Token: 0x04013926 RID: 80166
	public Vector3 middlePos = Vector3.zero;

	// Token: 0x04013927 RID: 80167
	public string namePath;

	// Token: 0x04013928 RID: 80168
	public string name;

	// Token: 0x04013929 RID: 80169
	public int nameNumberIdx = 1;

	// Token: 0x0401392A RID: 80170
	public ChaptertDungeonUnit[] chapterList = new ChaptertDungeonUnit[0];
}
