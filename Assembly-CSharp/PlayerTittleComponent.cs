using System;
using System.Collections.Generic;
using System.Text;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02004615 RID: 17941
public class PlayerTittleComponent : MonoBehaviour
{
	// Token: 0x0601938B RID: 103307 RVA: 0x007FA980 File Offset: 0x007F8D80
	public static void OnNotifyTittleChanged(uint iPlayerID, int iTittleID)
	{
		PlayerTittleComponent.OnChangedTittle(iPlayerID, iTittleID);
	}

	// Token: 0x0601938C RID: 103308 RVA: 0x007FA989 File Offset: 0x007F8D89
	public static void OnNotifyTownPlayerLvChanged(uint iPlayerID, int iLevel)
	{
		PlayerTittleComponent.OnChangedLv(iPlayerID, iLevel);
	}

	// Token: 0x0601938D RID: 103309 RVA: 0x007FA994 File Offset: 0x007F8D94
	private static void OnChangedLv(uint iPlayerID, int iLevel)
	{
		if (ClientSystem.IsTargetSystem<ClientSystemTown>())
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
			}
			if (clientSystemTown != null)
			{
				clientSystemTown.OnNotifyTownPlayerLvChanged(iPlayerID, iLevel);
			}
			return;
		}
	}

	// Token: 0x0601938E RID: 103310 RVA: 0x007FA9E0 File Offset: 0x007F8DE0
	private static void OnChangedTittle(uint iPlayerID, int iTittle)
	{
		if (ClientSystem.IsTargetSystem<ClientSystemTown>())
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
			}
			if (clientSystemTown != null)
			{
				clientSystemTown.OnNotifyTownPlayerTittleChanged(iPlayerID, iTittle);
			}
		}
	}

	// Token: 0x0601938F RID: 103311 RVA: 0x007FAA2C File Offset: 0x007F8E2C
	private void _Initialize()
	{
		StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
		for (int i = 0; i < this.goArray.Length; i++)
		{
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Status{0}", i + 1);
			this.goArray[i] = Utility.FindChild(base.transform.gameObject, stringBuilder.ToString());
			if (this.akTittleStatus[i] != null)
			{
				this.akTittleStatus[i].THIS = this;
				this.akTittleStatus[i].parent = base.transform.gameObject;
				this.akTittleStatus[i].self = Utility.FindChild(base.transform.gameObject, stringBuilder.ToString());
			}
		}
		StringBuilderCache.Release(stringBuilder);
		PlayerTittleComponent.TittleStatusOne tittleStatusOne = this.akTittleStatus[0] as PlayerTittleComponent.TittleStatusOne;
		tittleStatusOne.name = tittleStatusOne.self.GetComponent<Text>();
		PlayerTittleComponent.TittleStatusTwo tittleStatusTwo = this.akTittleStatus[1] as PlayerTittleComponent.TittleStatusTwo;
		tittleStatusTwo.pkLv = Utility.FindComponent<Image>(tittleStatusTwo.self, "pkLv", true);
		tittleStatusTwo.name = Utility.FindComponent<Text>(tittleStatusTwo.self, "Name", true);
		PlayerTittleComponent.TittleStatusThree tittleStatusThree = this.akTittleStatus[2] as PlayerTittleComponent.TittleStatusThree;
		tittleStatusThree.goAni = Utility.FindChild(tittleStatusThree.self, "Ani");
		tittleStatusThree.sizeConvert = Utility.FindComponent<TittleAniSizeConvert>(tittleStatusThree.self, "Ani", true);
		tittleStatusThree.icon = Utility.FindComponent<Image>(tittleStatusThree.self, "Icon", true);
		tittleStatusThree.lv = Utility.FindComponent<Text>(tittleStatusThree.self, "Status/Lv", true);
		tittleStatusThree.name = Utility.FindComponent<Text>(tittleStatusThree.self, "Status/Name", true);
		PlayerTittleComponent.TittleStatusFour tittleStatusFour = this.akTittleStatus[3] as PlayerTittleComponent.TittleStatusFour;
		tittleStatusFour.icon = Utility.FindComponent<Image>(tittleStatusFour.self, "Icon", true);
		tittleStatusFour.lv = Utility.FindComponent<Text>(tittleStatusFour.self, "Status/GangName", true);
		tittleStatusFour.name = Utility.FindComponent<Text>(tittleStatusFour.self, "Status/Name", true);
		PlayerTittleComponent.TittleStatusFive tittleStatusFive = this.akTittleStatus[4] as PlayerTittleComponent.TittleStatusFive;
		tittleStatusFive.lv = Utility.FindComponent<Text>(tittleStatusFive.self, "Lv", true);
		tittleStatusFive.name = Utility.FindComponent<Text>(tittleStatusFive.self, "Name", true);
		PlayerTittleComponent.TittleStatusSix tittleStatusSix = this.akTittleStatus[5] as PlayerTittleComponent.TittleStatusSix;
		tittleStatusSix.goAni = Utility.FindChild(tittleStatusSix.self, "Ani");
		tittleStatusSix.sizeConvert = Utility.FindComponent<TittleAniSizeConvert>(tittleStatusSix.self, "Ani", true);
		tittleStatusSix.lv = Utility.FindComponent<Text>(tittleStatusSix.self, "Status/Lv", true);
		tittleStatusSix.name = Utility.FindComponent<Text>(tittleStatusSix.self, "Status/Name", true);
		PlayerTittleComponent.TittleStatusSeven tittleStatusSeven = this.akTittleStatus[6] as PlayerTittleComponent.TittleStatusSeven;
		tittleStatusSeven.lv = Utility.FindComponent<Text>(tittleStatusSeven.self, "Lv", true);
		tittleStatusSeven.name = Utility.FindComponent<Text>(tittleStatusSeven.self, "Name", true);
		if (base.transform.parent != null)
		{
			this.info = base.transform.parent.GetComponent<CPlayerInfo>();
			Text component = Utility.FindChild(base.transform.parent.gameObject, "Bottom/Name").GetComponent<Text>();
			if (component != null)
			{
				component.gameObject.SetActive(false);
			}
			Text component2 = Utility.FindChild(base.transform.parent.gameObject, "Bottom/Lv").GetComponent<Text>();
			if (component2 != null)
			{
				component2.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06019390 RID: 103312 RVA: 0x007FADC7 File Offset: 0x007F91C7
	public void Initialize(int iTittleID, string name, string bangName, int iRoleLv, int iPkPoints = 0, PlayerInfoColor color = PlayerInfoColor.TOWN_PLAYER)
	{
		this.iTittleID = iTittleID;
		this.name = name;
		this.bangName = bangName;
		this.iRoleLv = iRoleLv;
		this.iPkPoints = iPkPoints;
		this.color = color;
		this._Initialize();
		this.OnTittleTypeChanged();
	}

	// Token: 0x06019391 RID: 103313 RVA: 0x007FAE02 File Offset: 0x007F9202
	public void SetLevel(int iRoleLv)
	{
		this.iRoleLv = iRoleLv;
		this.OnTittleTypeChanged();
	}

	// Token: 0x06019392 RID: 103314 RVA: 0x007FAE11 File Offset: 0x007F9211
	public void SetTittle(int iTittleID)
	{
		this.iTittleID = iTittleID;
		this.OnTittleTypeChanged();
	}

	// Token: 0x06019393 RID: 103315 RVA: 0x007FAE20 File Offset: 0x007F9220
	private void OnSetData()
	{
		for (int i = 0; i < this.akTittleStatus.Length; i++)
		{
			this.akTittleStatus[i].SetUIData();
		}
	}

	// Token: 0x06019394 RID: 103316 RVA: 0x007FAE54 File Offset: 0x007F9254
	private void OnSetTurn(PlayerTittleComponent.PlayStatusType eCurrent)
	{
		if (eCurrent >= PlayerTittleComponent.PlayStatusType.PST_1 && eCurrent < PlayerTittleComponent.PlayStatusType.PST_COUNT)
		{
			for (int i = 0; i < this.akTittleStatus.Length; i++)
			{
				if (eCurrent == (PlayerTittleComponent.PlayStatusType)i)
				{
					this.akTittleStatus[i].SetAcive(true);
					float lastTime = this.akTittleStatus[i].GetLastTime();
					base.Invoke("UpdateTurn", lastTime);
				}
				else
				{
					this.akTittleStatus[i].SetAcive(false);
				}
			}
		}
	}

	// Token: 0x06019395 RID: 103317 RVA: 0x007FAECC File Offset: 0x007F92CC
	private PlayerTittleComponent.TittlePlayType _GetTargetTittlePlayType()
	{
		this.bHasTittle = (this.iTittleID != 0);
		this.bHasGang = false;
		this.bHasVip = false;
		this.iMark = 0;
		int num = 0;
		this.iMark |= ((!this.bHasTittle) ? 0 : 1) << num;
		num++;
		this.iMark |= ((!this.bHasGang) ? 0 : 1) << num;
		num++;
		this.iMark |= ((!this.bHasVip) ? 0 : 1) << num;
		num++;
		return (PlayerTittleComponent.TittlePlayType)this.iMark;
	}

	// Token: 0x06019396 RID: 103318 RVA: 0x007FAF80 File Offset: 0x007F9380
	public void OnTittleTypeChanged()
	{
		this.eTittlePlayType = this._GetTargetTittlePlayType();
		this.OnSetData();
		this.OnResetTurn();
	}

	// Token: 0x06019397 RID: 103319 RVA: 0x007FAF9A File Offset: 0x007F939A
	public void OnLevelChanged(int iRoleLv)
	{
		this.iRoleLv = iRoleLv;
		this.OnTittleTypeChanged();
	}

	// Token: 0x06019398 RID: 103320 RVA: 0x007FAFA9 File Offset: 0x007F93A9
	public void OnTittleChanged(int iTittle)
	{
		this.iTittleID = iTittle;
		this.OnTittleTypeChanged();
	}

	// Token: 0x06019399 RID: 103321 RVA: 0x007FAFB8 File Offset: 0x007F93B8
	public void OnPkPointsChanged(int iPkPoints)
	{
		this.iPkPoints = iPkPoints;
		this.OnTittleTypeChanged();
	}

	// Token: 0x0601939A RID: 103322 RVA: 0x007FAFC7 File Offset: 0x007F93C7
	private void OnResetTurn()
	{
		this.iCurrentIndex = -1;
		this.UpdateTurn();
		base.CancelInvoke("UpdateTurn");
		base.Invoke("UpdateTurn", 0f);
	}

	// Token: 0x0601939B RID: 103323 RVA: 0x007FAFF1 File Offset: 0x007F93F1
	public void OnResetData()
	{
		this.OnSetData();
		this.OnResetTurn();
	}

	// Token: 0x0601939C RID: 103324 RVA: 0x007FB000 File Offset: 0x007F9400
	private void UpdateTurn()
	{
		if (this.eTittlePlayType >= PlayerTittleComponent.TittlePlayType.TPT_NOGANG_NOTITTLE && this.eTittlePlayType < PlayerTittleComponent.TittlePlayType.TPT_COUNT)
		{
			this.iCurrentIndex = (this.iCurrentIndex + 1) % this.akTurnList[(int)this.eTittlePlayType].Count;
			this.ePlayStatusType = (PlayerTittleComponent.PlayStatusType)(this.akTurnList[(int)this.eTittlePlayType][this.iCurrentIndex] - 1);
			this.OnSetTurn(this.ePlayStatusType);
		}
	}

	// Token: 0x0401212F RID: 74031
	private static Vector3 ms_tittleScale = new Vector3(150f, 150f, 150f);

	// Token: 0x04012130 RID: 74032
	private GameObject[] goArray = new GameObject[7];

	// Token: 0x04012131 RID: 74033
	private PlayerTittleComponent.PlayStatusType ePlayStatusType;

	// Token: 0x04012132 RID: 74034
	private int iCurrentIndex;

	// Token: 0x04012133 RID: 74035
	private float fNextCallTime;

	// Token: 0x04012134 RID: 74036
	private CPlayerInfo info;

	// Token: 0x04012135 RID: 74037
	private PlayerTittleComponent.TittleStatus[] akTittleStatus = new PlayerTittleComponent.TittleStatus[]
	{
		new PlayerTittleComponent.TittleStatusOne(),
		new PlayerTittleComponent.TittleStatusTwo(),
		new PlayerTittleComponent.TittleStatusThree(),
		new PlayerTittleComponent.TittleStatusFour(),
		new PlayerTittleComponent.TittleStatusFive(),
		new PlayerTittleComponent.TittleStatusSix(),
		new PlayerTittleComponent.TittleStatusSeven()
	};

	// Token: 0x04012136 RID: 74038
	private PlayerTittleComponent.TittlePlayType eTittlePlayType = PlayerTittleComponent.TittlePlayType.TPT_COUNT;

	// Token: 0x04012137 RID: 74039
	private List<int>[] akTurnList = new List<int>[]
	{
		new List<int>
		{
			1,
			2,
			5
		},
		new List<int>
		{
			1,
			2,
			3
		},
		new List<int>
		{
			2,
			4,
			5
		},
		new List<int>
		{
			2,
			3,
			4
		},
		new List<int>
		{
			1,
			2,
			7
		},
		new List<int>
		{
			1,
			2,
			6
		},
		new List<int>
		{
			2,
			7,
			4
		},
		new List<int>
		{
			2,
			6,
			4
		}
	};

	// Token: 0x04012138 RID: 74040
	private bool bHasTittle;

	// Token: 0x04012139 RID: 74041
	private bool bHasGang;

	// Token: 0x0401213A RID: 74042
	private bool bHasVip;

	// Token: 0x0401213B RID: 74043
	private int iMark;

	// Token: 0x0401213C RID: 74044
	private ItemTable tittleItem;

	// Token: 0x0401213D RID: 74045
	private int iTittleID;

	// Token: 0x0401213E RID: 74046
	private string name = string.Empty;

	// Token: 0x0401213F RID: 74047
	private string bangName = "[秋天童话&帮会]";

	// Token: 0x04012140 RID: 74048
	private int iRoleLv;

	// Token: 0x04012141 RID: 74049
	private int iPkPoints;

	// Token: 0x04012142 RID: 74050
	private PlayerInfoColor color;

	// Token: 0x02004616 RID: 17942
	private enum TittlePlayType
	{
		// Token: 0x04012144 RID: 74052
		TPT_NOGANG_NOTITTLE,
		// Token: 0x04012145 RID: 74053
		TPT_NOGANG_TITTLE,
		// Token: 0x04012146 RID: 74054
		TPT_GANG_NOTITTLE,
		// Token: 0x04012147 RID: 74055
		TPT_GANG_TITTLE,
		// Token: 0x04012148 RID: 74056
		TPT_VIP_NOGANG_NOTITTLE,
		// Token: 0x04012149 RID: 74057
		TPT_VIP_NOGANG_TITTLE,
		// Token: 0x0401214A RID: 74058
		TPT_VIP_GANG_NOTITTLE,
		// Token: 0x0401214B RID: 74059
		TPT_VIP_GANG_TITTLE,
		// Token: 0x0401214C RID: 74060
		TPT_COUNT,
		// Token: 0x0401214D RID: 74061
		TPT_TITTLE_STATUS = 5
	}

	// Token: 0x02004617 RID: 17943
	private enum PlayStatusType
	{
		// Token: 0x0401214F RID: 74063
		PST_1,
		// Token: 0x04012150 RID: 74064
		PST_2,
		// Token: 0x04012151 RID: 74065
		PST_3,
		// Token: 0x04012152 RID: 74066
		PST_4,
		// Token: 0x04012153 RID: 74067
		PST_5,
		// Token: 0x04012154 RID: 74068
		PST_6,
		// Token: 0x04012155 RID: 74069
		PST_7,
		// Token: 0x04012156 RID: 74070
		PST_COUNT
	}

	// Token: 0x02004618 RID: 17944
	private class TittleStatus
	{
		// Token: 0x0601939F RID: 103327 RVA: 0x007FB095 File Offset: 0x007F9495
		public virtual void SetUIData()
		{
		}

		// Token: 0x060193A0 RID: 103328 RVA: 0x007FB097 File Offset: 0x007F9497
		public virtual float GetLastTime()
		{
			if (this.tittleHelpComponent != null)
			{
				return this.tittleHelpComponent.fPlayerTime;
			}
			return 5f;
		}

		// Token: 0x060193A1 RID: 103329 RVA: 0x007FB0BC File Offset: 0x007F94BC
		public void SetAcive(bool bActive)
		{
			if (this.self != null && this.self.activeSelf != bActive)
			{
				this.self.gameObject.SetActive(bActive);
			}
			if (bActive && this.animator != null && this.tittleHelpComponent != null)
			{
				int layerIndex = this.animator.GetLayerIndex(this.tittleHelpComponent.LayerName);
				if (layerIndex != -1)
				{
					this.animator.Play(this.tittleHelpComponent.ClipName, layerIndex);
				}
			}
		}

		// Token: 0x060193A2 RID: 103330 RVA: 0x007FB15C File Offset: 0x007F955C
		protected void setName(Text text)
		{
			if (text != null)
			{
				text.text = this.THIS.name;
				if (this.THIS.info != null)
				{
					text.color = this.THIS.info.GetColor(this.THIS.color);
				}
			}
		}

		// Token: 0x060193A3 RID: 103331 RVA: 0x007FB1BD File Offset: 0x007F95BD
		protected void setGangName(Text text)
		{
			if (text != null)
			{
				text.text = this.THIS.bangName;
			}
		}

		// Token: 0x060193A4 RID: 103332 RVA: 0x007FB1DC File Offset: 0x007F95DC
		protected void setLevel(Text text)
		{
			if (text != null)
			{
				text.text = string.Format("Lv.{0}", this.THIS.iRoleLv);
			}
		}

		// Token: 0x060193A5 RID: 103333 RVA: 0x007FB20C File Offset: 0x007F960C
		protected void setAnimation(GameObject goAni, TittleAniSizeConvert sizeConvert, ref GameObject goTittle)
		{
			goTittle = null;
			if (goAni != null && sizeConvert != null)
			{
				this.THIS.tittleItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.THIS.iTittleID, string.Empty, string.Empty);
				if (this.THIS.tittleItem != null)
				{
					goTittle = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.THIS.tittleItem.ModelPath, false, 0U);
					if (goTittle != null)
					{
						for (int i = 0; i < goAni.transform.childCount; i++)
						{
							Transform child = goAni.transform.GetChild(i);
							if (child != null)
							{
								Object.Destroy(child.gameObject);
							}
						}
						goTittle.name = "tittle";
						Utility.AttachTo(goTittle, goAni, false);
						this.tittleHelpComponent = goTittle.GetComponent<TittleHelpComponent>();
						this.animator = goTittle.GetComponent<Animator>();
						sizeConvert.ResetTarget(goTittle.transform, 1f, 1f, 100);
					}
				}
			}
		}

		// Token: 0x060193A6 RID: 103334 RVA: 0x007FB324 File Offset: 0x007F9724
		protected void setPkPoints(Image Grade, int pkPoints)
		{
			if (Grade != null && pkPoints >= 0)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				bool flag = false;
				string pathByPkPoints = Utility.GetPathByPkPoints((uint)pkPoints, ref num, ref num2, ref num3, ref flag);
				if (pathByPkPoints != string.Empty && pathByPkPoints != "-" && pathByPkPoints != "0")
				{
					ETCImageLoader.LoadSprite(ref Grade, pathByPkPoints, true);
					Grade.SetNativeSize();
				}
			}
		}

		// Token: 0x04012157 RID: 74071
		public PlayerTittleComponent THIS;

		// Token: 0x04012158 RID: 74072
		public GameObject parent;

		// Token: 0x04012159 RID: 74073
		public GameObject self;

		// Token: 0x0401215A RID: 74074
		private TittleHelpComponent tittleHelpComponent;

		// Token: 0x0401215B RID: 74075
		private Animator animator;
	}

	// Token: 0x02004619 RID: 17945
	private class TittleStatusOne : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193A8 RID: 103336 RVA: 0x007FB3A8 File Offset: 0x007F97A8
		public override void SetUIData()
		{
			base.setName(this.name);
		}

		// Token: 0x0401215C RID: 74076
		public Text name;
	}

	// Token: 0x0200461A RID: 17946
	private class TittleStatusTwo : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193AA RID: 103338 RVA: 0x007FB3BE File Offset: 0x007F97BE
		public override void SetUIData()
		{
			base.setName(this.name);
			base.setPkPoints(this.pkLv, this.THIS.iPkPoints);
		}

		// Token: 0x0401215D RID: 74077
		public Image pkLv;

		// Token: 0x0401215E RID: 74078
		public Text name;
	}

	// Token: 0x0200461B RID: 17947
	private class TittleStatusThree : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193AC RID: 103340 RVA: 0x007FB3EC File Offset: 0x007F97EC
		public override void SetUIData()
		{
			base.setAnimation(this.goAni, this.sizeConvert, ref this.goTittle);
			base.setLevel(this.lv);
			base.setName(this.name);
			if (this.icon.gameObject.activeSelf)
			{
				this.icon.gameObject.SetActive(false);
			}
		}

		// Token: 0x0401215F RID: 74079
		public GameObject goAni;

		// Token: 0x04012160 RID: 74080
		public TittleAniSizeConvert sizeConvert;

		// Token: 0x04012161 RID: 74081
		private GameObject goTittle;

		// Token: 0x04012162 RID: 74082
		public Image icon;

		// Token: 0x04012163 RID: 74083
		public Text lv;

		// Token: 0x04012164 RID: 74084
		public Text name;
	}

	// Token: 0x0200461C RID: 17948
	private class TittleStatusFour : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193AE RID: 103342 RVA: 0x007FB457 File Offset: 0x007F9857
		public override void SetUIData()
		{
			base.setGangName(this.lv);
			base.setName(this.name);
		}

		// Token: 0x04012165 RID: 74085
		public Image icon;

		// Token: 0x04012166 RID: 74086
		public Text lv;

		// Token: 0x04012167 RID: 74087
		public Text name;
	}

	// Token: 0x0200461D RID: 17949
	private class TittleStatusFive : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193B0 RID: 103344 RVA: 0x007FB479 File Offset: 0x007F9879
		public override void SetUIData()
		{
			base.setLevel(this.lv);
			base.setName(this.name);
		}

		// Token: 0x04012168 RID: 74088
		public Text lv;

		// Token: 0x04012169 RID: 74089
		public Text name;
	}

	// Token: 0x0200461E RID: 17950
	private class TittleStatusSix : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193B2 RID: 103346 RVA: 0x007FB49B File Offset: 0x007F989B
		public override void SetUIData()
		{
			base.setAnimation(this.goAni, this.sizeConvert, ref this.goTittle);
			base.setLevel(this.lv);
			base.setName(this.name);
		}

		// Token: 0x0401216A RID: 74090
		public GameObject goAni;

		// Token: 0x0401216B RID: 74091
		public TittleAniSizeConvert sizeConvert;

		// Token: 0x0401216C RID: 74092
		private GameObject goTittle;

		// Token: 0x0401216D RID: 74093
		public Text lv;

		// Token: 0x0401216E RID: 74094
		public Text name;
	}

	// Token: 0x0200461F RID: 17951
	private class TittleStatusSeven : PlayerTittleComponent.TittleStatus
	{
		// Token: 0x060193B4 RID: 103348 RVA: 0x007FB4D5 File Offset: 0x007F98D5
		public override void SetUIData()
		{
			base.setLevel(this.lv);
			base.setName(this.name);
		}

		// Token: 0x0401216F RID: 74095
		public Text lv;

		// Token: 0x04012170 RID: 74096
		public Text name;
	}
}
