using System;
using UnityEngine;

// Token: 0x02000D7F RID: 3455
public interface IGeAvatarActor
{
	// Token: 0x06008C0E RID: 35854
	void ChangeAction(string actionName, float speed = 1f, bool loop = false);

	// Token: 0x06008C0F RID: 35855
	string GetCurActionName();

	// Token: 0x06008C10 RID: 35856
	void ChangeAvatar(GeAvatarChannel eChannel, string modulePath, bool isAsync = false, bool highPriority = false);

	// Token: 0x06008C11 RID: 35857
	void ChangeAvatar(GeAvatarChannel eChannel, DAssetObject asset, bool isAsync = false, bool highPriority = false);

	// Token: 0x06008C12 RID: 35858
	void SuitAvatar(bool isAsync = false, bool highPriority = false);

	// Token: 0x06008C13 RID: 35859
	GeAttach AttachAvatar(string attachmentName, string attachRes, string attachNode, bool needClear = true, bool asyncLoad = true, bool highPriority = false, float fAttHeight = 0f);

	// Token: 0x06008C14 RID: 35860
	void RemoveAttach(GeAttach attachment);

	// Token: 0x06008C15 RID: 35861
	GeAttach GetAttachment(string name);

	// Token: 0x06008C16 RID: 35862
	GeEffectEx CreateEffect(string effectRes, string attachNode, float fTime, EffectTimeType timeType, Vector3 localPos, Quaternion localRot, float initScale = 1f, float fSpeed = 1f, bool isLoop = false);

	// Token: 0x06008C17 RID: 35863
	void OnUpdate(float fDelta);
}
