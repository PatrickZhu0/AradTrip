using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D54 RID: 3412
	public interface IUIEffect
	{
		// Token: 0x06008A9F RID: 35487
		EUIEffType GetEffectType();

		// Token: 0x06008AA0 RID: 35488
		Vector3 GetPosition();

		// Token: 0x06008AA1 RID: 35489
		void SetPosition(Vector3 pos);

		// Token: 0x06008AA2 RID: 35490
		Vector3 GetRotation();

		// Token: 0x06008AA3 RID: 35491
		void SetRotation(Vector3 rot);

		// Token: 0x06008AA4 RID: 35492
		Vector3 GetScale();

		// Token: 0x06008AA5 RID: 35493
		void SetScale(Vector3 scale);

		// Token: 0x06008AA6 RID: 35494
		void GetTransform(out Vector3 pos, out Vector3 rot, out Vector3 scale);

		// Token: 0x06008AA7 RID: 35495
		void SetTransform(uint unMask, Vector3 pos, Vector3 rot, Vector3 scale);
	}
}
