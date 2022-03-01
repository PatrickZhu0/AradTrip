using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000D35 RID: 3381
	public class TextRendererManager
	{
		// Token: 0x060089F4 RID: 35316 RVA: 0x00192EA8 File Offset: 0x001912A8
		public void Init()
		{
			this.m_NormalHurtTextRenderer = this.InstantiateTextRendererPrefab(this.m_NormalHurtTextRendererPrefabPath);
			this.m_NormalHurtWhiteTextRenderer = this.InstantiateTextRendererPrefab(this.m_NormalHurtWhiteTextRendererPrefabPath);
			this.m_CriticleHurtTextRenderer = this.InstantiateTextRendererPrefab(this.m_CriticleHurtTextRendererPrefabPath);
			this.m_CriticleHurtWhiteTextRenderer = this.InstantiateTextRendererPrefab(this.m_CriticleHurtWhiteTextRendererPrefabPath);
			this.m_HurtOwnTextRenderer = this.InstantiateTextRendererPrefab(this.m_HurtOwnTextRendererPrefabPath);
			this.m_HurtOwnWhiteTextRenderer = this.InstantiateTextRendererPrefab(this.m_HurtOwnWhiteTextRendererPrefabPath);
			this.m_BuffHurtTextRenderer = this.InstantiateTextRendererPrefab(this.m_BuffHurtTextRendererPrefabPath);
			this.m_BuffHurtWhiteTextRenderer = this.InstantiateTextRendererPrefab(this.m_BuffHurtWhiteTextRendererPrefabPath);
			this.m_HurtFriendTextRenderer = this.InstantiateTextRendererPrefab(this.m_HurtFriendTextRendererPrefabPath);
			this.m_HPTextRenderer = this.InstantiateTextRendererPrefab(this.m_HPTextRendererPrefabPath);
			this.m_MPTextRenderer = this.InstantiateTextRendererPrefab(this.m_MPTextRendererPrefabPath);
			this.m_NormalAttachTextRenderer = this.InstantiateTextRendererPrefab(this.m_NormalAttachTextRendererPrefabPath);
			this.m_CriticleAttachTextRenderer = this.InstantiateTextRendererPrefab(this.m_CriticleAttachTextRendererPrefabPath);
			this.m_CriticleHurtImageRenderer = this.InstantiateImageRendererPrefab(this.m_CriticleHurtImageRendererPrefabPath);
			this.m_MissImageRenderer = this.InstantiateImageRendererPrefab(this.m_MissImageRendererPrefabPath);
			this.m_BuffNameTextRenderer = this.InstantiateTextRendererPrefab(this.m_BuffNameTextRendererPrefabPath);
			this.m_BuffNameTextRenderer.PreLoadFontCharacter("减加速眩晕石化出血感电睡眠冰冻束缚混乱中毒隐身灼伤失明物理魔法荆棘反伤攻速移速提升释放速度攻击强化暴击恢复防御提升吸血属性智力体力");
		}

		// Token: 0x060089F5 RID: 35317 RVA: 0x00192FE8 File Offset: 0x001913E8
		private TextRenderer InstantiateTextRendererPrefab(string path)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.Layer3DRoot, false);
			TextRenderer component = gameObject.GetComponent<TextRenderer>();
			component.Init();
			return component;
		}

		// Token: 0x060089F6 RID: 35318 RVA: 0x00193024 File Offset: 0x00191424
		private ImageRenderer InstantiateImageRendererPrefab(string path)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			Utility.AttachTo(gameObject, Singleton<ClientSystemManager>.instance.Layer3DRoot, false);
			ImageRenderer component = gameObject.GetComponent<ImageRenderer>();
			component.Init();
			return component;
		}

		// Token: 0x060089F7 RID: 35319 RVA: 0x00193060 File Offset: 0x00191460
		public void Update()
		{
			this.CheckInit();
			this.m_NormalAttachTextRenderer.UpdateMesh();
			this.m_CriticleAttachTextRenderer.UpdateMesh();
			this.m_NormalHurtTextRenderer.UpdateMesh();
			this.m_NormalHurtWhiteTextRenderer.UpdateMesh();
			this.m_CriticleHurtTextRenderer.UpdateMesh();
			this.m_CriticleHurtWhiteTextRenderer.UpdateMesh();
			this.m_HurtOwnTextRenderer.UpdateMesh();
			this.m_HurtOwnWhiteTextRenderer.UpdateMesh();
			this.m_BuffHurtTextRenderer.UpdateMesh();
			this.m_BuffHurtWhiteTextRenderer.UpdateMesh();
			this.m_HurtFriendTextRenderer.UpdateMesh();
			this.m_HPTextRenderer.UpdateMesh();
			this.m_MPTextRenderer.UpdateMesh();
			this.m_CriticleHurtImageRenderer.UpdateMesh();
			this.m_MissImageRenderer.UpdateMesh();
			this.m_BuffNameTextRenderer.UpdateMesh();
		}

		// Token: 0x060089F8 RID: 35320 RVA: 0x00193124 File Offset: 0x00191524
		public void AddText(int num, Vec3 position, int actorID, ShowHitComponent.HitResType resType, HitTextAniType animType, int hitEffectType, int animCurveIndex)
		{
			this.CheckInit();
			switch (resType)
			{
			case ShowHitComponent.HitResType.NORMAL:
				this.m_NormalHurtTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				this.m_NormalHurtWhiteTextRenderer.AddText(num, new Vec3(position.x, position.y, position.z - 0.1f), actorID, hitEffectType, (int)animType, 0);
				break;
			case ShowHitComponent.HitResType.CRITICAL:
				this.m_CriticleHurtTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				this.m_CriticleHurtWhiteTextRenderer.AddText(num, new Vec3(position.x, position.y, position.z - 0.1f), actorID, hitEffectType, (int)animType, 0);
				this.m_CriticleHurtImageRenderer.AddImage(position, actorID, hitEffectType, 0);
				break;
			case ShowHitComponent.HitResType.MISS:
				this.m_MissImageRenderer.AddImage(position, actorID, hitEffectType, 0);
				break;
			case ShowHitComponent.HitResType.OWN_HURT:
				this.m_HurtOwnTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				this.m_HurtOwnWhiteTextRenderer.AddText(num, new Vec3(position.x, position.y, position.z - 0.1f), actorID, hitEffectType, (int)animType, 0);
				break;
			case ShowHitComponent.HitResType.BUFF_HURT:
				this.m_BuffHurtTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				this.m_BuffHurtWhiteTextRenderer.AddText(num, new Vec3(position.x, position.y, position.z - 0.1f), actorID, hitEffectType, (int)animType, 0);
				break;
			case ShowHitComponent.HitResType.FRIEND_HURT:
				this.m_HurtFriendTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				break;
			case ShowHitComponent.HitResType.TEXT_HP:
				this.m_HPTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				break;
			case ShowHitComponent.HitResType.TEXT_MP:
				this.m_MPTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				break;
			case ShowHitComponent.HitResType.NORMAL_ATTACH:
				this.m_NormalAttachTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, animCurveIndex);
				break;
			case ShowHitComponent.HitResType.CRITICAL_ATTACH:
				this.m_CriticleAttachTextRenderer.AddText(num, position, actorID, hitEffectType, (int)animType, 0);
				break;
			}
		}

		// Token: 0x060089F9 RID: 35321 RVA: 0x0019333F File Offset: 0x0019173F
		public void AddNameText(string text, Vec3 position, int actorID, ShowHitComponent.HitResType resType, HitTextAniType animType, int hitEffectType, int animCurveIndex)
		{
			this.CheckInit();
			if (resType == ShowHitComponent.HitResType.TEXT_BUFF_NAME)
			{
				this.m_BuffNameTextRenderer.AddNameText(text, position, actorID, hitEffectType, (int)animType, 0);
			}
		}

		// Token: 0x060089FA RID: 35322 RVA: 0x0019336C File Offset: 0x0019176C
		public void MoveUpAll(int hitEffectType, int actorID, HitTextAniType animType)
		{
			this.m_NormalAttachTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
			switch (hitEffectType)
			{
			case 0:
				this.m_HurtFriendTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_HurtOwnTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_HurtOwnWhiteTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				break;
			case 1:
				this.m_NormalHurtTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_NormalHurtWhiteTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_CriticleHurtTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_CriticleHurtWhiteTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_CriticleHurtImageRenderer.MoveUpAll(actorID, hitEffectType);
				this.m_CriticleAttachTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_HurtOwnTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_HurtOwnWhiteTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_HurtFriendTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				break;
			case 2:
				this.m_HurtOwnTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_HurtOwnWhiteTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_BuffHurtTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				this.m_BuffHurtWhiteTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				break;
			case 3:
				this.m_HPTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				break;
			case 4:
				this.m_MPTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				break;
			case 5:
				this.m_BuffNameTextRenderer.MoveUpAll(actorID, hitEffectType, (int)animType);
				break;
			}
		}

		// Token: 0x060089FB RID: 35323 RVA: 0x001934D6 File Offset: 0x001918D6
		private void CheckInit()
		{
			if (this.m_NormalHurtTextRenderer == null)
			{
				this.Init();
			}
		}

		// Token: 0x040043AF RID: 17327
		private string m_NormalHurtTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/NormalHurtTextRenderer";

		// Token: 0x040043B0 RID: 17328
		private string m_NormalHurtWhiteTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/NormalHurtWhiteTextRenderer";

		// Token: 0x040043B1 RID: 17329
		private string m_CriticleHurtTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/CriticleHurtTextRenderer";

		// Token: 0x040043B2 RID: 17330
		private string m_CriticleHurtWhiteTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/CriticleHurtWhiteTextRenderer";

		// Token: 0x040043B3 RID: 17331
		private string m_CriticleHurtImageRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/CriticleHurtImageRenderer";

		// Token: 0x040043B4 RID: 17332
		private string m_HurtOwnTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/HurtOwnTextRenderer";

		// Token: 0x040043B5 RID: 17333
		private string m_HurtOwnWhiteTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/HurtOwnWhiteTextRenderer";

		// Token: 0x040043B6 RID: 17334
		private string m_BuffHurtTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/BuffHurtTextRenderer";

		// Token: 0x040043B7 RID: 17335
		private string m_BuffHurtWhiteTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/BuffHurtWhiteTextRenderer";

		// Token: 0x040043B8 RID: 17336
		private string m_HurtFriendTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/HurtFriendTextRenderer";

		// Token: 0x040043B9 RID: 17337
		private string m_HPTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/HPTextRenderer";

		// Token: 0x040043BA RID: 17338
		private string m_MPTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/MPTextRenderer";

		// Token: 0x040043BB RID: 17339
		private string m_NormalAttachTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/NormalAttachTextRenderer";

		// Token: 0x040043BC RID: 17340
		private string m_CriticleAttachTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/CriticleAttachTextRenderer";

		// Token: 0x040043BD RID: 17341
		private string m_MissImageRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/MissImageRenderer";

		// Token: 0x040043BE RID: 17342
		private string m_BuffNameTextRendererPrefabPath = "UIFlatten/Prefabs/Battle_Digit/New/BuffNameTextRenderer";

		// Token: 0x040043BF RID: 17343
		private TextRenderer m_NormalHurtTextRenderer;

		// Token: 0x040043C0 RID: 17344
		private TextRenderer m_NormalHurtWhiteTextRenderer;

		// Token: 0x040043C1 RID: 17345
		private TextRenderer m_CriticleHurtTextRenderer;

		// Token: 0x040043C2 RID: 17346
		private TextRenderer m_CriticleHurtWhiteTextRenderer;

		// Token: 0x040043C3 RID: 17347
		private TextRenderer m_HurtOwnTextRenderer;

		// Token: 0x040043C4 RID: 17348
		private TextRenderer m_HurtOwnWhiteTextRenderer;

		// Token: 0x040043C5 RID: 17349
		private TextRenderer m_BuffHurtTextRenderer;

		// Token: 0x040043C6 RID: 17350
		private TextRenderer m_BuffHurtWhiteTextRenderer;

		// Token: 0x040043C7 RID: 17351
		private TextRenderer m_HurtFriendTextRenderer;

		// Token: 0x040043C8 RID: 17352
		private TextRenderer m_HPTextRenderer;

		// Token: 0x040043C9 RID: 17353
		private TextRenderer m_MPTextRenderer;

		// Token: 0x040043CA RID: 17354
		private TextRenderer m_NormalAttachTextRenderer;

		// Token: 0x040043CB RID: 17355
		private TextRenderer m_CriticleAttachTextRenderer;

		// Token: 0x040043CC RID: 17356
		private TextRenderer m_BuffNameTextRenderer;

		// Token: 0x040043CD RID: 17357
		private ImageRenderer m_CriticleHurtImageRenderer;

		// Token: 0x040043CE RID: 17358
		private ImageRenderer m_MissImageRenderer;
	}
}
