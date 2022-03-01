using System;
using UnityEngine;

// Token: 0x02000CE7 RID: 3303
[CreateAssetMenu(fileName = "AvatarFallbackAsset", menuName = "Client/AvatarFallback", order = 0)]
public class GeAvatarFallbackAsset : ScriptableObject
{
	// Token: 0x0400411C RID: 16668
	[SerializeField]
	public AvatarFallbackDictionary avatarDic = new AvatarFallbackDictionary();
}
