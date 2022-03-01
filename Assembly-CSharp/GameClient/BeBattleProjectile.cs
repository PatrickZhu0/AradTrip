using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001140 RID: 4416
	public sealed class BeBattleProjectile : BeBaseFighter
	{
		// Token: 0x0600A886 RID: 43142 RVA: 0x00237E3E File Offset: 0x0023623E
		public BeBattleProjectile(BeBattleProjectile.BeBulletData data, ClientSystemGameBattle systemTown) : base(data, systemTown)
		{
		}

		// Token: 0x0600A887 RID: 43143 RVA: 0x00237E54 File Offset: 0x00236254
		private void OnDestroy()
		{
			base.Remove();
			if (this._geActor != null && this._geScene != null)
			{
				string effectPath = "Effects/Common/Sfx/Hit/Prefab/Eff_hit_guai02_guo";
				if (this._geActor.GetResID() == 730039)
				{
					effectPath = "Effects/Scene_effects/Scene_Chiji/Prefab/Eff_Scene_Chiji_shoulei_shouji";
				}
				else if (this._geActor.GetResID() == 730040)
				{
					effectPath = "Effects/Scene_effects/Scene_Chiji/Prefab/Eff_Scene_Chiji_feibiao_shouji";
				}
				Vector3 position = this._geActor.GetPosition();
				Vec3 initPos = new Vec3(position.x, position.z, position.y);
				this._geScene.CreateEffect(effectPath, 0f, initPos, 1f, 1f, false, false);
			}
		}

		// Token: 0x0600A888 RID: 43144 RVA: 0x00237F05 File Offset: 0x00236305
		public override void OnRemove()
		{
			this.Dispose();
		}

		// Token: 0x0600A889 RID: 43145 RVA: 0x00237F10 File Offset: 0x00236310
		public override void UpdateMove(float timeElapsed)
		{
			base.UpdateMove(timeElapsed);
			if (this._geActor != null)
			{
				this.durTime += timeElapsed;
				Vector3 position = this._geActor.GetPosition();
				BeBattleProjectile.BeBulletData beBulletData = this._data as BeBattleProjectile.BeBulletData;
				if (beBulletData == null)
				{
					return;
				}
				BeFighter player = this.GetPlayer(beBulletData.targetId);
				if (player == null)
				{
					this.OnDestroy();
					return;
				}
				Vector3 position2 = player.ActorData.MoveData.Position;
				Vector2 vector = position2.xz() - position.xz();
				Vector2 vector2 = vector;
				vector2.Normalize();
				Vector2 vector3 = vector2 * this.speed * timeElapsed;
				position.x += vector3.x;
				position.z += vector3.y;
				Vector2 vector4 = position2.xz() - position.xz();
				Vector3 vector5;
				vector5..ctor(player.ActorData.MoveData.Position.x, 0f, player.ActorData.MoveData.Position.z);
				Vector3 vector6;
				vector6..ctor(base.ActorData.MoveData.Position.x, 0f, base.ActorData.MoveData.Position.z);
				Vector3 vector7 = vector5 - vector6;
				vector7.Normalize();
				if (vector7 != Vector3.zero && this._geActor != null)
				{
					float num = Quaternion.LookRotation(vector7).eulerAngles.y - 90f;
					this._geActor.GetEntityNode(GeEntity.GeEntityNodeType.Root).transform.localRotation = Quaternion.Euler(0f, num, 0f);
				}
				if (vector.sqrMagnitude <= vector4.sqrMagnitude)
				{
					position.x = position2.x;
					position.z = position2.z;
					base.ActorData.MoveData.Position = position;
					this.OnDestroy();
				}
				else
				{
					base.ActorData.MoveData.Position = position;
				}
			}
		}

		// Token: 0x0600A88A RID: 43146 RVA: 0x00238148 File Offset: 0x00236548
		public override void InitGeActor(GeSceneEx geScene)
		{
			this._geScene = geScene;
			if (this._geScene == null)
			{
				this.OnDestroy();
				return;
			}
			BeBattleProjectile.BeBulletData beBulletData = this._data as BeBattleProjectile.BeBulletData;
			if (beBulletData == null)
			{
				this.OnDestroy();
				return;
			}
			BeFighter player = this.GetPlayer(beBulletData.attackId);
			if (player == null)
			{
				this.OnDestroy();
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(beBulletData.typeId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("Projectile id {0} is Invalid", new object[]
				{
					beBulletData.typeId
				});
				this.OnDestroy();
				return;
			}
			this._geActor = this._geScene.CreateActor(tableItem.ResID, 0, 0, false, true, true, false);
			if (this._geActor == null)
			{
				this.OnDestroy();
				return;
			}
			Vector3 position = player.ActorData.MoveData.Position;
			position.y = 1f;
			base.ActorData.MoveData.Position = position;
			base.InitGeActor(geScene);
		}

		// Token: 0x0600A88B RID: 43147 RVA: 0x0023824B File Offset: 0x0023664B
		private BeFighter GetPlayer(ulong objId)
		{
			if (this._battle == null)
			{
				return null;
			}
			return this._battle.GetPlayer(objId);
		}

		// Token: 0x04005E23 RID: 24099
		public float durTime;

		// Token: 0x04005E24 RID: 24100
		public float speed = 10f;

		// Token: 0x02001141 RID: 4417
		public sealed class BeBulletData : BeBaseActorData
		{
			// Token: 0x04005E25 RID: 24101
			public ulong attackId;

			// Token: 0x04005E26 RID: 24102
			public ulong targetId;

			// Token: 0x04005E27 RID: 24103
			public int typeId;

			// Token: 0x04005E28 RID: 24104
			public int damageValue;
		}
	}
}
