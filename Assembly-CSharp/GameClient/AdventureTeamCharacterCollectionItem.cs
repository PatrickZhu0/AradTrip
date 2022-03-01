using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001407 RID: 5127
	public class AdventureTeamCharacterCollectionItem : MonoBehaviour
	{
		// Token: 0x0600C683 RID: 50819 RVA: 0x002FE928 File Offset: 0x002FCD28
		private void Awake()
		{
			if (this.bind == null)
			{
				Logger.LogError("[AdventureTeamCharacterCollectionItem] - comBind is null");
				return;
			}
			this.hasjobRoot = this.bind.GetGameObject("hasjobRoot");
			this.nojobRoot = this.bind.GetGameObject("nojobRoot");
			this.jobPhoto = this.bind.GetCom<Image>("jobPhoto");
			this.jobName = this.bind.GetCom<Image>("jobName");
			this.jobinfoGray = this.bind.GetCom<UIGray>("jobinfoGray");
			this.effectRoot = this.bind.GetGameObject("effectRoot");
		}

		// Token: 0x0600C684 RID: 50820 RVA: 0x002FE9D8 File Offset: 0x002FCDD8
		private void OnDestroy()
		{
			this.hasjobRoot = null;
			this.nojobRoot = null;
			this.jobPhoto = null;
			this.jobName = null;
			this.jobinfoGray = null;
			this.effectRoot = null;
			this.unlockEffectGo = null;
			this.unlockEffectRed = null;
			this.unlockEffectMat = null;
			this.Clear();
		}

		// Token: 0x0600C685 RID: 50821 RVA: 0x002FEA2C File Offset: 0x002FCE2C
		public void Clear()
		{
			if (this.onWaitActiveEffectPlayEnd != null)
			{
				Delegate[] invocationList = this.onWaitActiveEffectPlayEnd.GetInvocationList();
				if (invocationList != null)
				{
					for (int i = 0; i < invocationList.Length; i++)
					{
						this.onWaitActiveEffectPlayEnd = (AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler)Delegate.Remove(this.onWaitActiveEffectPlayEnd, invocationList[i] as AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler);
					}
				}
			}
			this.onWaitActiveEffectPlayEnd = null;
			if (this.waitToPlayUnlockAnim != null)
			{
				base.StopCoroutine(this.waitToPlayUnlockAnim);
				this.waitToPlayUnlockAnim = null;
			}
			this.tempModel = null;
			if (this.unlockEffectGo != null)
			{
				this.unlockEffectGo.CustomActive(false);
			}
		}

		// Token: 0x0600C686 RID: 50822 RVA: 0x002FEAD4 File Offset: 0x002FCED4
		public void InitCollectionItem(CharacterCollectionModel collectionModel)
		{
			this.tempModel = collectionModel;
			if (collectionModel == null)
			{
				return;
			}
			bool isJobOpened = collectionModel.isJobOpened;
			bool isOwned = collectionModel.isOwned;
			bool needPlay = collectionModel.needPlay;
			string jobPhotoPath = collectionModel.jobPhotoPath;
			string jobNamePath = collectionModel.jobNamePath;
			this.hasjobRoot.CustomActive(isJobOpened);
			this.nojobRoot.CustomActive(!isJobOpened);
			if (!isJobOpened)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			if (!string.IsNullOrEmpty(jobPhotoPath))
			{
				flag = ETCImageLoader.LoadSprite(ref this.jobPhoto, jobPhotoPath, true);
			}
			if (!string.IsNullOrEmpty(jobNamePath))
			{
				flag2 = ETCImageLoader.LoadSprite(ref this.jobName, jobNamePath, true);
			}
			if (!flag2 || !flag)
			{
				this.hasjobRoot.CustomActive(false);
				this.nojobRoot.CustomActive(true);
				return;
			}
			this._SetRoleActivatedStatus(isOwned && !needPlay);
		}

		// Token: 0x0600C687 RID: 50823 RVA: 0x002FEBAB File Offset: 0x002FCFAB
		private void _SetRoleActivatedStatus(bool bActivated)
		{
			if (this.jobinfoGray)
			{
				this.jobinfoGray.SetEnable(!bActivated);
			}
		}

		// Token: 0x0600C688 RID: 50824 RVA: 0x002FEBCC File Offset: 0x002FCFCC
		public void PlayNewJobActivate()
		{
			if (!DataManager<AdventureTeamDataManager>.GetInstance().CheckIsSelectJobSatisfyConditions(this.tempModel))
			{
				return;
			}
			if (!this.tempModel.needPlay)
			{
				return;
			}
			this._ShowUnlockEffect(true);
		}

		// Token: 0x0600C689 RID: 50825 RVA: 0x002FEBFC File Offset: 0x002FCFFC
		private void _ShowUnlockEffect(bool bShow)
		{
			if (bShow)
			{
				this._CreateEffectObj();
			}
			if (this.unlockEffectGo != null)
			{
				this.unlockEffectGo.CustomActive(bShow);
			}
			if (bShow)
			{
				this._SetRoleActivatedStatus(true);
				if (this.waitToPlayUnlockAnim != null)
				{
					base.StopCoroutine(this.waitToPlayUnlockAnim);
				}
				this.waitToPlayUnlockAnim = base.StartCoroutine(this._WaitToPlayUnlockAnim());
			}
		}

		// Token: 0x0600C68A RID: 50826 RVA: 0x002FEC68 File Offset: 0x002FD068
		private void _CreateEffectObj()
		{
			if (this.unlockEffectGo == null)
			{
				this.unlockEffectGo = this._LoadEffectByResPath("Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_juesejiesuo");
				Utility.AttachTo(this.unlockEffectGo, this.effectRoot, false);
			}
			if (this.unlockEffectGo == null)
			{
				return;
			}
			this.unlockEffectGo.transform.localScale = new Vector3(2f, 2f, 2f);
			AdventureTeamCharacterCollectionUnlockEffectBind component = this.unlockEffectGo.GetComponent<AdventureTeamCharacterCollectionUnlockEffectBind>();
			if (component == null)
			{
				return;
			}
			this.unlockEffectRed = component.renderer;
			if (this.unlockEffectRed != null)
			{
				this.unlockEffectMat = this.unlockEffectRed.material;
			}
			if (this.tempModel != null)
			{
				string[] array = this.tempModel.jobPhotoPath.Split(new char[]
				{
					':'
				});
				if (array != null && array.Length >= 2)
				{
					Texture texture = Singleton<AssetLoader>.instance.LoadRes(array[0], typeof(Texture), true, 0U).obj as Texture;
					this._SetUnlockMatTexture(texture);
				}
			}
		}

		// Token: 0x0600C68B RID: 50827 RVA: 0x002FED88 File Offset: 0x002FD188
		private IEnumerator _WaitToPlayUnlockAnim()
		{
			yield return Yielders.GetWaitForSeconds(this.totalUnlockAnimDuration);
			if (this.onWaitActiveEffectPlayEnd != null)
			{
				this.onWaitActiveEffectPlayEnd(this.tempModel);
			}
			yield break;
		}

		// Token: 0x0600C68C RID: 50828 RVA: 0x002FEDA3 File Offset: 0x002FD1A3
		private void _SetUnlockMatTexture(Texture texture)
		{
			if (texture == null)
			{
				return;
			}
			if (this.unlockEffectMat != null)
			{
				this.unlockEffectMat.SetTexture("_MainTex", texture);
			}
		}

		// Token: 0x0600C68D RID: 50829 RVA: 0x002FEDD4 File Offset: 0x002FD1D4
		private GameObject _LoadEffectByResPath(string effectPath)
		{
			GameObject result = null;
			if (string.IsNullOrEmpty(effectPath))
			{
				return result;
			}
			return Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(effectPath, true, 0U);
		}

		// Token: 0x040071E5 RID: 29157
		private const string EFFUI_NEW_ACTIVATED_ROLE_UNLOCK_RES_PATH = "Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_juesejiesuo";

		// Token: 0x040071E6 RID: 29158
		[SerializeField]
		private ComCommonBind bind;

		// Token: 0x040071E7 RID: 29159
		[Space(10f)]
		[Header("解锁动画时长")]
		[SerializeField]
		private float totalUnlockAnimDuration = 3f;

		// Token: 0x040071E8 RID: 29160
		private GameObject hasjobRoot;

		// Token: 0x040071E9 RID: 29161
		private GameObject nojobRoot;

		// Token: 0x040071EA RID: 29162
		private Image jobPhoto;

		// Token: 0x040071EB RID: 29163
		private Image jobName;

		// Token: 0x040071EC RID: 29164
		private UIGray jobinfoGray;

		// Token: 0x040071ED RID: 29165
		private GameObject effectRoot;

		// Token: 0x040071EE RID: 29166
		private Coroutine waitToPlayUnlockAnim;

		// Token: 0x040071EF RID: 29167
		private CharacterCollectionModel tempModel;

		// Token: 0x040071F0 RID: 29168
		private GameObject unlockEffectGo;

		// Token: 0x040071F1 RID: 29169
		private MeshRenderer unlockEffectRed;

		// Token: 0x040071F2 RID: 29170
		private Material unlockEffectMat;

		// Token: 0x040071F3 RID: 29171
		[HideInInspector]
		public AdventureTeamCharacterCollectionItem.WaitActiveEffectPlayEndHandler onWaitActiveEffectPlayEnd;

		// Token: 0x02001408 RID: 5128
		// (Invoke) Token: 0x0600C68F RID: 50831
		public delegate void WaitActiveEffectPlayEndHandler(CharacterCollectionModel model);
	}
}
