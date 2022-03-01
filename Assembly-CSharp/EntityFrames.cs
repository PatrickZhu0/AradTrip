using System;
using UnityEngine;

// Token: 0x02004BAE RID: 19374
[Serializable]
public class EntityFrames
{
	// Token: 0x0601C75F RID: 116575 RVA: 0x0089EFD0 File Offset: 0x0089D3D0
	public void Copy(EntityFrames src)
	{
		this.name = src.name;
		this.resID = src.resID;
		this.type = src.type;
		this.startFrames = src.startFrames;
		this.entityPrefab = src.entityPrefab;
		this.entityAsset = src.entityAsset;
		this.gravity = src.gravity;
		this.speed = src.speed;
		this.angle = src.angle;
		this.isAngleWithEffect = src.isAngleWithEffect;
		this.emitposition = src.emitposition;
		this.emitPositionZ = src.emitPositionZ;
		this.axisType = src.axisType;
		this.shockTime = src.shockTime;
		this.shockSpeed = src.shockSpeed;
		this.shockRangeX = src.shockRangeX;
		this.shockRangeY = src.shockRangeY;
		this.isRotation = src.isRotation;
		this.rotateSpeed = src.rotateSpeed;
		this.moveSpeed = src.moveSpeed;
		this.rotateInitDegree = src.rotateInitDegree;
		this.followRotate = src.followRotate;
		this.sceneShock = src.sceneShock;
		this.hitFallUP = src.hitFallUP;
		this.forceY = src.forceY;
		this.hurtID = src.hurtID;
		this.lifeTime = src.lifeTime;
		this.hitThrough = src.hitThrough;
		this.hitCount = src.hitCount;
		this.distance = src.distance;
		this.attackCountExceedPlayExtDead = src.attackCountExceedPlayExtDead;
		this.hitGroundClick = src.hitGroundClick;
		this.delayDead = src.delayDead;
		this.offsetType = src.offsetType;
		this.targetChooseType = src.targetChooseType;
		this.range = src.range;
		this.boomerangeDistance = src.boomerangeDistance;
		this.stayDuration = src.stayDuration;
		this.paraSpeed = src.paraSpeed;
		this.paraGravity = src.paraGravity;
		this.useRandomLaunch = src.useRandomLaunch;
		this.randomLaunchInfo = src.randomLaunchInfo;
		this.onCollideDie = src.onCollideDie;
		this.onXInBlockDie = src.onXInBlockDie;
		this.changForceBehindOther = src.changForceBehindOther;
		this.changeFace = src.changeFace;
	}

	// Token: 0x04013977 RID: 80247
	public string name;

	// Token: 0x04013978 RID: 80248
	public int resID;

	// Token: 0x04013979 RID: 80249
	public EntityType type;

	// Token: 0x0401397A RID: 80250
	public bool randomResID;

	// Token: 0x0401397B RID: 80251
	public int[] resIDList = new int[0];

	// Token: 0x0401397C RID: 80252
	public int startFrames;

	// Token: 0x0401397D RID: 80253
	public GameObject entityPrefab;

	// Token: 0x0401397E RID: 80254
	public DAssetObject entityAsset;

	// Token: 0x0401397F RID: 80255
	public Vector2 gravity;

	// Token: 0x04013980 RID: 80256
	public float speed;

	// Token: 0x04013981 RID: 80257
	public float angle;

	// Token: 0x04013982 RID: 80258
	public bool isAngleWithEffect = true;

	// Token: 0x04013983 RID: 80259
	public Vector2 emitposition;

	// Token: 0x04013984 RID: 80260
	public float emitPositionZ;

	// Token: 0x04013985 RID: 80261
	public AxisType axisType = AxisType.Z;

	// Token: 0x04013986 RID: 80262
	public float shockTime;

	// Token: 0x04013987 RID: 80263
	public float shockSpeed;

	// Token: 0x04013988 RID: 80264
	public float shockRangeX;

	// Token: 0x04013989 RID: 80265
	public float shockRangeY;

	// Token: 0x0401398A RID: 80266
	public bool isRotation;

	// Token: 0x0401398B RID: 80267
	public float rotateSpeed;

	// Token: 0x0401398C RID: 80268
	public float moveSpeed;

	// Token: 0x0401398D RID: 80269
	public int rotateInitDegree;

	// Token: 0x0401398E RID: 80270
	public bool followRotate;

	// Token: 0x0401398F RID: 80271
	public ShockInfo sceneShock;

	// Token: 0x04013990 RID: 80272
	public int hitFallUP;

	// Token: 0x04013991 RID: 80273
	public float forceY;

	// Token: 0x04013992 RID: 80274
	public int hurtID;

	// Token: 0x04013993 RID: 80275
	public float lifeTime;

	// Token: 0x04013994 RID: 80276
	public bool hitThrough;

	// Token: 0x04013995 RID: 80277
	public int hitCount = 1;

	// Token: 0x04013996 RID: 80278
	public float distance = 999999f;

	// Token: 0x04013997 RID: 80279
	public bool attackCountExceedPlayExtDead;

	// Token: 0x04013998 RID: 80280
	public bool hitGroundClick;

	// Token: 0x04013999 RID: 80281
	public float delayDead;

	// Token: 0x0401399A RID: 80282
	public OffsetType offsetType;

	// Token: 0x0401399B RID: 80283
	public TargetChooseType targetChooseType;

	// Token: 0x0401399C RID: 80284
	public Vector2 range;

	// Token: 0x0401399D RID: 80285
	public float boomerangeDistance = 2.5f;

	// Token: 0x0401399E RID: 80286
	public float stayDuration;

	// Token: 0x0401399F RID: 80287
	public float paraSpeed = 5f;

	// Token: 0x040139A0 RID: 80288
	public float paraGravity = 18f;

	// Token: 0x040139A1 RID: 80289
	public bool useRandomLaunch;

	// Token: 0x040139A2 RID: 80290
	public RandomLaunchInfo randomLaunchInfo;

	// Token: 0x040139A3 RID: 80291
	public bool onCollideDie;

	// Token: 0x040139A4 RID: 80292
	public bool onXInBlockDie;

	// Token: 0x040139A5 RID: 80293
	public bool changForceBehindOther;

	// Token: 0x040139A6 RID: 80294
	public int changeFace;
}
