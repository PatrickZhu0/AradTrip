using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F04 RID: 3844
	internal class ComMapPlayer : MonoBehaviour
	{
		// Token: 0x17001912 RID: 6418
		// (get) Token: 0x06009636 RID: 38454 RVA: 0x001C6C65 File Offset: 0x001C5065
		public bool isValid
		{
			get
			{
				return this.m_scene != null && this.m_player != null;
			}
		}

		// Token: 0x17001913 RID: 6419
		// (get) Token: 0x06009637 RID: 38455 RVA: 0x001C6C87 File Offset: 0x001C5087
		public ComMapScene scene
		{
			get
			{
				return this.m_scene;
			}
		}

		// Token: 0x17001914 RID: 6420
		// (get) Token: 0x06009638 RID: 38456 RVA: 0x001C6C8F File Offset: 0x001C508F
		public Vector3 ServerPos
		{
			get
			{
				return this.m_serverPos;
			}
		}

		// Token: 0x06009639 RID: 38457 RVA: 0x001C6C9C File Offset: 0x001C509C
		public void Initialize()
		{
			this.Clear();
		}

		// Token: 0x0600963A RID: 38458 RVA: 0x001C6CA4 File Offset: 0x001C50A4
		public void Setup(BeTownPlayer a_player, ComMapScene a_comScene)
		{
			if (a_player != null && a_comScene != null)
			{
				this.m_player = a_player;
				this.m_scene = a_comScene;
				base.gameObject.SetActive(true);
				base.gameObject.transform.SetParent(this.m_scene.gameObject.transform, false);
				this._UpdatePos();
			}
		}

		// Token: 0x0600963B RID: 38459 RVA: 0x001C6D04 File Offset: 0x001C5104
		public void Setup(BeFighterMain a_player, ComMapScene a_comScene)
		{
			if (a_player != null && a_comScene != null)
			{
				this.m_fighterPlayer = a_player;
				this.m_scene = a_comScene;
				base.gameObject.SetActive(true);
				base.gameObject.transform.SetParent(this.m_scene.gameObject.transform, false);
				this._UpdatePos();
			}
		}

		// Token: 0x0600963C RID: 38460 RVA: 0x001C6D64 File Offset: 0x001C5164
		public void UpdateJobID(int JobTableID)
		{
			if (this.m_player != null)
			{
				this.m_player.SetPlayerJobTableID(JobTableID);
			}
		}

		// Token: 0x0600963D RID: 38461 RVA: 0x001C6D7D File Offset: 0x001C517D
		public void Update()
		{
			this._UpdatePos();
		}

		// Token: 0x0600963E RID: 38462 RVA: 0x001C6D85 File Offset: 0x001C5185
		public void Clear()
		{
			this.m_player = null;
			this.m_scene = null;
			base.gameObject.SetActive(false);
			this.m_serverPos = Vector2.zero;
		}

		// Token: 0x0600963F RID: 38463 RVA: 0x001C6DAC File Offset: 0x001C51AC
		private void _UpdatePos()
		{
			if (this.m_player != null && this.m_scene != null)
			{
				BeBaseActorData actorData = this.m_player.ActorData;
				if (actorData != null)
				{
					ActorMoveData moveData = actorData.MoveData;
					if (moveData != null)
					{
						Vector3 serverPosition = moveData.ServerPosition;
						base.gameObject.transform.localPosition = new Vector3(serverPosition.x * this.m_scene.XRate, serverPosition.z * this.m_scene.ZRate, 0f);
						this.m_serverPos.x = serverPosition.x;
						this.m_serverPos.y = serverPosition.z;
					}
				}
			}
			else if (this.m_fighterPlayer != null && this.m_scene != null)
			{
				BeBaseActorData actorData2 = this.m_fighterPlayer.ActorData;
				if (actorData2 != null)
				{
					ActorMoveData moveData2 = actorData2.MoveData;
					if (moveData2 != null)
					{
						Vector3 serverPosition2 = moveData2.ServerPosition;
						base.gameObject.transform.localPosition = new Vector3(serverPosition2.x * this.m_scene.XRate, serverPosition2.z * this.m_scene.ZRate, 0f);
						this.m_serverPos.x = serverPosition2.x;
						this.m_serverPos.y = serverPosition2.z;
					}
				}
			}
		}

		// Token: 0x04004D14 RID: 19732
		private BeTownPlayer m_player;

		// Token: 0x04004D15 RID: 19733
		private ComMapScene m_scene;

		// Token: 0x04004D16 RID: 19734
		private BeFighterMain m_fighterPlayer;

		// Token: 0x04004D17 RID: 19735
		private Vector2 m_serverPos = Vector2.zero;
	}
}
