using System;
using System.IO;
using UnityEngine;

// Token: 0x02000D71 RID: 3441
public class GeDemoActor : IGeAvatarActor
{
	// Token: 0x06008BA9 RID: 35753 RVA: 0x0019BBBC File Offset: 0x00199FBC
	protected void _Init()
	{
		if (null == this.m_ActorRoot)
		{
			this.m_ActorRoot = new GameObject("DemoAvatar");
		}
		if (this.m_Avatar == null)
		{
			this.m_Avatar = new GeAvatar(false);
		}
		if (this.m_Animation == null)
		{
			this.m_Animation = new GeAnimationManager();
		}
		if (this.m_Attachment == null)
		{
			this.m_Attachment = new GeAttachManager();
		}
		if (this.m_Effect == null)
		{
			this.m_Effect = new GeEffectManager();
		}
		if (this.m_ActorState == null)
		{
			this.m_ActorState = new GeActorState();
		}
	}

	// Token: 0x06008BAA RID: 35754 RVA: 0x0019BC5C File Offset: 0x0019A05C
	public void Deinit()
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.Deinit();
			this.m_Animation = null;
		}
		if (this.m_Attachment != null)
		{
			this.m_Attachment.Deinit();
			this.m_Attachment = null;
		}
		if (this.m_Effect != null)
		{
			this.m_Effect.Deinit();
			this.m_Effect = null;
		}
		if (this.m_Avatar != null)
		{
			GameObject avatarRoot = this.m_Avatar.GetAvatarRoot();
			if (avatarRoot)
			{
				avatarRoot.transform.SetParent(null, true);
			}
			this.m_Avatar.Deinit();
			this.m_Avatar = null;
		}
		if (this.m_ModelDataAsset != null)
		{
			this.m_ModelDataAsset = null;
			this.m_ModelData = null;
		}
		if (this.m_ActorState != null)
		{
			this.m_ActorState.Deinit();
			this.m_ActorState = null;
		}
		if (null != this.m_ActorRoot)
		{
			this.m_ActorRoot.transform.SetParent(null, true);
			Object.Destroy(this.m_ActorRoot);
			this.m_ActorRoot = null;
		}
	}

	// Token: 0x06008BAB RID: 35755 RVA: 0x0019BD6C File Offset: 0x0019A16C
	public static string GetAvatarResPath(string resPath)
	{
		if (!string.IsNullOrEmpty(resPath))
		{
			string value = "Actor/";
			if (resPath.StartsWith(value))
			{
				int num = resPath.IndexOf("Prefabs");
				if (0 <= num && num < resPath.Length)
				{
					string text = resPath.Substring(0, num - 1);
					string[] array = text.Split(new char[]
					{
						'/'
					});
					string str = array[array.Length - 1];
					return text + "/" + str;
				}
			}
		}
		return null;
	}

	// Token: 0x06008BAC RID: 35756 RVA: 0x0019BDEC File Offset: 0x0019A1EC
	public void LoadAvatar(string avatarRes, bool isAsync = false)
	{
		this.Deinit();
		this._Init();
		if (!string.IsNullOrEmpty(avatarRes))
		{
			string value = "Actor/";
			this.m_AvatarPath = string.Empty;
			if (avatarRes.StartsWith(value))
			{
				int num = avatarRes.IndexOf("Prefabs");
				if (0 <= num && num < avatarRes.Length)
				{
					this.m_AvatarPath = avatarRes.Substring(0, num - 1);
					string[] array = this.m_AvatarPath.Split(new char[]
					{
						'/'
					});
					this.m_AvatarName = array[array.Length - 1];
					if (this.m_AvatarName.Contains("Hero_") || this.m_AvatarName.Contains("Monster_"))
					{
						this.m_ModelDataAsset = Singleton<AssetLoader>.instance.LoadRes(this.GetModelDataPath(), typeof(ScriptableObject), false, 0U);
						if (this.m_ModelDataAsset != null)
						{
							this.m_ModelData = (this.m_ModelDataAsset.obj as DModelData);
							if (this.m_ModelData)
							{
								if (this.m_Avatar.Init(this.m_ModelData.modelAvatar.m_AssetPath, 9, true, false, false))
								{
									this.m_Avatar.GetAvatarRoot().transform.SetParent(this.m_ActorRoot.transform, false);
									for (int i = 0; i < this.m_ModelData.partsChunk.Length; i++)
									{
										int partChannel = (int)this.m_ModelData.partsChunk[i].partChannel;
										if (0 <= partChannel && partChannel < GeDemoActor.avatarChanTbl.Length)
										{
											this.ChangeAvatar(GeDemoActor.avatarChanTbl[partChannel], this.m_ModelData.partsChunk[i].partAsset, false, false);
										}
									}
									this.m_Attachment.RefreshAttachNode(this.m_Avatar.GetSkeletonRoot(), false, false);
									this.m_Animation.Init(this.m_Avatar.GetAvatarRoot());
									this.m_Animation.PlayAction("Anim_Idle_special", 1f, false, 0f);
									this.m_ActorState.Init(this);
								}
								else
								{
									this.ChangeAvatar(GeAvatarChannel.WholeBody, new DAssetObject(avatarRes, false), false, false);
								}
								return;
							}
							Logger.LogErrorFormat("Init avatar has failed with resource path {0}", new object[]
							{
								avatarRes
							});
						}
					}
				}
			}
		}
	}

	// Token: 0x06008BAD RID: 35757 RVA: 0x0019C044 File Offset: 0x0019A444
	public void ClearAvatar()
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.ClearAll();
		}
		this.m_Attachment.ClearAll();
	}

	// Token: 0x06008BAE RID: 35758 RVA: 0x0019C067 File Offset: 0x0019A467
	public void LoadState(string skillDataRes)
	{
		this.m_ActorState.LoadState(skillDataRes);
	}

	// Token: 0x06008BAF RID: 35759 RVA: 0x0019C075 File Offset: 0x0019A475
	public void ChangeState(string state)
	{
		this.m_ActorState.ChangeState(state);
	}

	// Token: 0x06008BB0 RID: 35760 RVA: 0x0019C083 File Offset: 0x0019A483
	public string GetModelDataPath()
	{
		return this.m_AvatarPath + "/" + this.m_AvatarName;
	}

	// Token: 0x06008BB1 RID: 35761 RVA: 0x0019C09C File Offset: 0x0019A49C
	public void ChangeAvatar(GeAvatarChannel eChannel, string modulePath, bool isAsync = false, bool highPriority = false)
	{
		DAssetObject asset = new DAssetObject(null, modulePath);
		this.ChangeAvatar(eChannel, asset, isAsync, false);
	}

	// Token: 0x06008BB2 RID: 35762 RVA: 0x0019C0BC File Offset: 0x0019A4BC
	public void ChangeAvatar(GeAvatarChannel eChannel, DAssetObject asset, bool isAsync = false, bool highPriority = false)
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.ChangeAvatarObject(eChannel, asset, isAsync, false, 0);
			this.m_avatarDirty = true;
		}
	}

	// Token: 0x06008BB3 RID: 35763 RVA: 0x0019C0E0 File Offset: 0x0019A4E0
	public void SuitAvatar(bool isAsync = false, bool highPriority = false)
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.SuitAvatar(isAsync, false, 0);
		}
	}

	// Token: 0x06008BB4 RID: 35764 RVA: 0x0019C0FC File Offset: 0x0019A4FC
	protected void _OverwriteMaterial()
	{
		GameObject[] suitPartModel = this.m_Avatar.suitPartModel;
		string text = this.m_AvatarPath.Replace('\\', '/');
		if (text[text.Length - 1] == '/')
		{
			text.Remove(text.Length - 1);
		}
		int num = text.LastIndexOf('/');
		if (0 <= num && num < text.Length)
		{
			text = text.Substring(0, num);
		}
		int i = 0;
		int num2 = suitPartModel.Length;
		while (i < num2)
		{
			GameObject gameObject = suitPartModel[i];
			string path = string.Empty;
			string name = gameObject.name;
			if (name.Contains("_Pant"))
			{
				path = "Pant";
			}
			else if (name.Contains("_Head"))
			{
				path = "Head";
			}
			else if (name.Contains("_Body"))
			{
				path = "Body";
			}
			SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			int j = 0;
			int num3 = componentsInChildren.Length;
			while (j < num3)
			{
				Material[] materials = componentsInChildren[j].materials;
				int k = 0;
				int num4 = materials.Length;
				while (k < num4)
				{
					string text2 = materials[k].name;
					if ((text2[0] == 'm' || text2[0] == 'M') && text2[1] == '_')
					{
						text2 = text2.Substring(2);
					}
					int num5 = -1;
					if (text2.Contains("_Pant"))
					{
						num5 = text2.LastIndexOf("_Pant");
					}
					else if (text2.Contains("_Head"))
					{
						num5 = text2.LastIndexOf("_Head");
					}
					else if (text2.Contains("_Body"))
					{
						num5 = text2.LastIndexOf("_Body");
					}
					else if (text2.Contains("_Hair"))
					{
						num5 = text2.LastIndexOf("_Hair");
					}
					if (0 <= num5 && num5 < text2.Length)
					{
						text2 = text2.Substring(0, num5);
					}
					string path2 = Path.Combine(Path.Combine(Path.Combine(Path.Combine(text, text2), path), "Material"), materials[k].name.Replace(" (Instance)", null) + "_Show");
					Material material = Singleton<AssetLoader>.instance.LoadRes(path2, typeof(Material), true, 0U).obj as Material;
					if (null != material)
					{
						materials[k] = material;
					}
					k++;
				}
				componentsInChildren[j].materials = materials;
				j++;
			}
			i++;
		}
	}

	// Token: 0x06008BB5 RID: 35765 RVA: 0x0019C3B4 File Offset: 0x0019A7B4
	public GeAttach AttachAvatar(string attachmentName, string attachRes, string attachNode, bool needClear = true, bool asyncLoad = true, bool highPriority = false, float fAttHeight = 0f)
	{
		if (this.m_Attachment != null)
		{
			this.m_Attachment.ClearAttachmentOnNode(attachNode);
			GeAttach geAttach = this.m_Attachment.AddAttachment(attachmentName, attachRes, attachNode, true, asyncLoad, highPriority);
			if (geAttach != null)
			{
				geAttach.SetLayer(9);
			}
			if (fAttHeight != 0f)
			{
				Vector3 localPosition = geAttach.root.transform.localPosition;
				localPosition.y = fAttHeight;
				geAttach.root.transform.localPosition = localPosition;
			}
			return geAttach;
		}
		return null;
	}

	// Token: 0x06008BB6 RID: 35766 RVA: 0x0019C434 File Offset: 0x0019A834
	public void RemoveAttach(GeAttach attachment)
	{
		if (this.m_Attachment != null)
		{
			this.m_Attachment.RemoveAttachment(attachment);
		}
	}

	// Token: 0x06008BB7 RID: 35767 RVA: 0x0019C44D File Offset: 0x0019A84D
	public GeAttach GetAttachment(string name)
	{
		if (this.m_Attachment != null)
		{
			return this.m_Attachment.GetAttachment(name, null);
		}
		return null;
	}

	// Token: 0x06008BB8 RID: 35768 RVA: 0x0019C46C File Offset: 0x0019A86C
	public GameObject GeAttachNode(string name)
	{
		if (this.m_Attachment != null)
		{
			return this.m_Attachment.GetAttchNodeDesc(name).attachNode;
		}
		return null;
	}

	// Token: 0x06008BB9 RID: 35769 RVA: 0x0019C49A File Offset: 0x0019A89A
	public void ChangeAction(string actionName, float speed = 1f, bool loop = false)
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.PlayAction(actionName, speed, loop, 0f);
		}
		if (this.m_Attachment != null)
		{
			this.m_Attachment.ChangeAction(actionName, speed, false);
		}
	}

	// Token: 0x06008BBA RID: 35770 RVA: 0x0019C4D4 File Offset: 0x0019A8D4
	public string GetCurActionName()
	{
		if (this.m_Animation != null)
		{
			this.m_Animation.GetCurActionName();
		}
		return string.Empty;
	}

	// Token: 0x06008BBB RID: 35771 RVA: 0x0019C4F4 File Offset: 0x0019A8F4
	public GeEffectEx CreateEffect(string effectRes, string attachNode, float fTime, EffectTimeType timeType, Vector3 localPos, Quaternion localRot, float initScale = 1f, float fSpeed = 1f, bool isLoop = false)
	{
		EffectsFrames effectsFrames = new EffectsFrames();
		effectsFrames.localPosition = localPos;
		effectsFrames.localRotation = localRot;
		effectsFrames.localScale = new Vector3(initScale, initScale, initScale);
		if (attachNode == null || string.Empty == attachNode)
		{
			attachNode = "None";
		}
		effectsFrames.attachname = attachNode;
		GeAttachManager.GeAttachNodeDesc attchNodeDesc = this.m_Attachment.GetAttchNodeDesc(attachNode);
		if (!string.IsNullOrEmpty(effectRes))
		{
			DAssetObject effectRes2;
			effectRes2.m_AssetObj = null;
			effectRes2.m_AssetPath = effectRes;
			GeEffectEx geEffectEx = this.m_Effect.AddEffect(effectRes2, effectsFrames, fTime, new Vector3(0f, 0f, 0f), attchNodeDesc.attachNode, false, false);
			if (geEffectEx != null)
			{
				bool flag = false;
				if (timeType == EffectTimeType.GLOBAL_ANIMATION)
				{
					flag = true;
				}
				else if (geEffectEx.GetDefaultTimeLen() < fTime)
				{
					flag = true;
				}
				geEffectEx.SetSpeed(fSpeed);
				geEffectEx.Play(flag || isLoop);
				return geEffectEx;
			}
		}
		return null;
	}

	// Token: 0x06008BBC RID: 35772 RVA: 0x0019C5EA File Offset: 0x0019A9EA
	public void ClearEffect()
	{
		this.m_Effect.ClearAll(GeEffectType.EffectUnique);
		this.m_Effect.ClearAll(GeEffectType.EffectMultiple);
		this.m_Effect.ClearAll(GeEffectType.EffectGlobal);
	}

	// Token: 0x06008BBD RID: 35773 RVA: 0x0019C610 File Offset: 0x0019AA10
	public void ChangeLayer(int layer)
	{
		if (this.m_Avatar != null)
		{
			this.m_Avatar.ChangeLayer(layer);
		}
	}

	// Token: 0x06008BBE RID: 35774 RVA: 0x0019C62C File Offset: 0x0019AA2C
	public void OnUpdate(float fDelta)
	{
		if (this.m_Avatar != null)
		{
			if (!this.m_Avatar.IsLoadFinished())
			{
				this.m_Avatar.UpdateAsyncLoading();
			}
			else if (this.m_avatarDirty)
			{
				this.m_Avatar.SetAvatarVisible(true);
				GameObject avatarRoot = this.m_Avatar.GetAvatarRoot();
				if (null != avatarRoot)
				{
					SkinnedMeshRenderer[] componentsInChildren = avatarRoot.GetComponentsInChildren<SkinnedMeshRenderer>();
					if (componentsInChildren != null)
					{
						int i = 0;
						int num = componentsInChildren.Length;
						while (i < num)
						{
							componentsInChildren[i].updateWhenOffscreen = true;
							i++;
						}
					}
				}
				this._OverwriteMaterial();
				this.m_avatarDirty = false;
			}
		}
		if (fDelta > 0f)
		{
			this.m_ActorState.Update(fDelta);
			this.m_Attachment.Update();
			int deltaTime = (int)(fDelta * 1000f);
			this.m_Effect.Update(deltaTime, GeEffectType.EffectGlobal);
			this.m_Effect.Update(deltaTime, GeEffectType.EffectMultiple);
			this.m_Effect.Update(deltaTime, GeEffectType.EffectUnique);
		}
	}

	// Token: 0x06008BBF RID: 35775 RVA: 0x0019C722 File Offset: 0x0019AB22
	public bool IsCurActionEnd()
	{
		return this.m_Animation == null || this.m_Animation.IsCurAnimFinished();
	}

	// Token: 0x1700189B RID: 6299
	// (get) Token: 0x06008BC0 RID: 35776 RVA: 0x0019C73C File Offset: 0x0019AB3C
	public GameObject avatarRoot
	{
		get
		{
			return this.m_ActorRoot;
		}
	}

	// Token: 0x040044FA RID: 17658
	private GeAvatar m_Avatar;

	// Token: 0x040044FB RID: 17659
	private GeAnimationManager m_Animation;

	// Token: 0x040044FC RID: 17660
	private GeAttachManager m_Attachment;

	// Token: 0x040044FD RID: 17661
	private GeEffectManager m_Effect;

	// Token: 0x040044FE RID: 17662
	protected AssetInst m_ModelDataAsset;

	// Token: 0x040044FF RID: 17663
	protected DModelData m_ModelData;

	// Token: 0x04004500 RID: 17664
	protected GeActorState m_ActorState;

	// Token: 0x04004501 RID: 17665
	protected string m_AvatarPath;

	// Token: 0x04004502 RID: 17666
	protected string m_AvatarName;

	// Token: 0x04004503 RID: 17667
	private GameObject m_ActorRoot;

	// Token: 0x04004504 RID: 17668
	private static readonly GeAvatarChannel[] avatarChanTbl = new GeAvatarChannel[]
	{
		GeAvatarChannel.Head,
		GeAvatarChannel.UpperPart,
		GeAvatarChannel.LowerPart,
		GeAvatarChannel.Bracelet,
		GeAvatarChannel.Headwear,
		GeAvatarChannel.Wings
	};

	// Token: 0x04004505 RID: 17669
	protected bool m_avatarDirty;
}
