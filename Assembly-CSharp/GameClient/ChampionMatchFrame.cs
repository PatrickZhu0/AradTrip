using System;
using System.Collections.Generic;
using Battle;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200107C RID: 4220
	public class ChampionMatchFrame : ClientFrame
	{
		// Token: 0x06009F79 RID: 40825 RVA: 0x001FE9EE File Offset: 0x001FCDEE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Champion/ChampionMatch";
		}

		// Token: 0x06009F7A RID: 40826 RVA: 0x001FE9F8 File Offset: 0x001FCDF8
		private void _initMatchData()
		{
			List<string> list = this._getNameList();
			List<string> list2 = this._getMatchList();
			for (int i = 0; i < list2.Count; i++)
			{
				list.Remove(list2[i]);
			}
			list.Sort((string x, string y) => Random.Range(0, 3) - 1);
			ChampionMatchFrame.matchTree[0] = this.player.GetPlayerName();
			for (int j = 0; j < 15; j++)
			{
				string text = ChampionMatchFrame.matchTree[j];
				if (text == this.player.GetPlayerName())
				{
					string text2 = list2[0];
					list2.RemoveAt(0);
					ChampionMatchFrame.matchTree[j * 2 + 1] = text;
					ChampionMatchFrame.matchTree[j * 2 + 2] = text2;
					ChampionMatchFrame.lineState[j * 2 + 1] = true;
					ChampionMatchFrame.lineState[j * 2 + 2] = false;
				}
				else
				{
					string text2 = list[0];
					list.RemoveAt(0);
					if (Random.Range(0, 2) == 0)
					{
						ChampionMatchFrame.matchTree[j * 2 + 1] = text;
						ChampionMatchFrame.matchTree[j * 2 + 2] = text2;
						ChampionMatchFrame.lineState[j * 2 + 1] = true;
						ChampionMatchFrame.lineState[j * 2 + 2] = false;
					}
					else
					{
						ChampionMatchFrame.matchTree[j * 2 + 1] = text2;
						ChampionMatchFrame.matchTree[j * 2 + 2] = text;
						ChampionMatchFrame.lineState[j * 2 + 1] = false;
						ChampionMatchFrame.lineState[j * 2 + 2] = true;
					}
				}
			}
		}

		// Token: 0x06009F7B RID: 40827 RVA: 0x001FEB6C File Offset: 0x001FCF6C
		private List<string> _getNameList()
		{
			List<string> list = new List<string>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<ChampionBattleTable>();
			foreach (object obj in table.Values)
			{
				ChampionBattleTable championBattleTable = (ChampionBattleTable)obj;
				if (!list.Contains(championBattleTable.Name))
				{
					list.Add(championBattleTable.Name);
				}
			}
			return list;
		}

		// Token: 0x06009F7C RID: 40828 RVA: 0x001FEBF8 File Offset: 0x001FCFF8
		private List<string> _getMatchList()
		{
			List<string> list = new List<string>();
			List<DungeonArea> areas = this.battle.dungeonManager.GetDungeonDataManager().battleInfo.areas;
			if (areas.Count != this.matchRound)
			{
				Logger.LogError("房间数量不为 4 ！！！！！");
			}
			else
			{
				for (int i = 0; i < this.matchRound; i++)
				{
					int num = areas[i].id / 10;
					ChampionBattleTable tableItem = Singleton<TableManager>.instance.GetTableItem<ChampionBattleTable>(num, string.Empty, string.Empty);
					if (tableItem != null)
					{
						list.Add(tableItem.Name);
						if (i == this.matchRound - 1)
						{
							ChampionMatchFrame.bossIcon = tableItem.Icon;
						}
					}
					else
					{
						Logger.LogErrorFormat("擂台关卡表里不包含ID为 {0} 的行！！！！！", new object[]
						{
							num
						});
					}
				}
			}
			list.Reverse();
			return list;
		}

		// Token: 0x06009F7D RID: 40829 RVA: 0x001FECD8 File Offset: 0x001FD0D8
		protected override void _bindExUI()
		{
			this.btnPass = this.mBind.GetCom<Button>("pass");
			this.btnPass.onClick.AddListener(new UnityAction(this._onPassClicked));
			this.txtTimer = this.mBind.GetCom<Text>("timer");
			this.leftPart = this.mBind.GetCom<RectTransform>("leftPart");
			this.rightPart = this.mBind.GetCom<RectTransform>("rightPart");
			this.leftAni = this.mBind.GetCom<DOTweenAnimation>("leftAni");
			this.rightAni = this.mBind.GetCom<DOTweenAnimation>("rightAni");
			this.topAni = this.mBind.GetCom<DOTweenAnimation>("topAni");
			this.dui = this.mBind.GetGameObject("dui");
			this.jue = this.mBind.GetGameObject("jue");
			this.effect1 = this.mBind.GetGameObject("effect1");
			this.effect1.SetActive(false);
			this.effect2 = this.mBind.GetGameObject("effect2");
			this.effect2.SetActive(false);
			this.effect3 = this.mBind.GetGameObject("effect3");
			this.effect3.SetActive(false);
			this.effect4 = this.mBind.GetGameObject("effect4");
			this.effect4.SetActive(false);
		}

		// Token: 0x06009F7E RID: 40830 RVA: 0x001FEE50 File Offset: 0x001FD250
		protected override void _unbindExUI()
		{
			this.btnPass.onClick.RemoveListener(new UnityAction(this._onPassClicked));
			this.btnPass = null;
			this.txtTimer = null;
			this.leftPart = null;
			this.rightPart = null;
			this.leftAni = null;
			this.rightAni = null;
			this.topAni = null;
			this.dui = null;
			this.jue = null;
			this.effect1 = null;
			this.effect2 = null;
			this.effect3 = null;
			this.effect4 = null;
		}

		// Token: 0x06009F7F RID: 40831 RVA: 0x001FEED4 File Offset: 0x001FD2D4
		private void _onPassClicked()
		{
			base.Close(false);
		}

		// Token: 0x06009F80 RID: 40832 RVA: 0x001FEEDD File Offset: 0x001FD2DD
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x06009F81 RID: 40833 RVA: 0x001FEEE0 File Offset: 0x001FD2E0
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06009F82 RID: 40834 RVA: 0x001FEEE3 File Offset: 0x001FD2E3
		private void _initUIObjects()
		{
			if (this.frame == null)
			{
				return;
			}
			this._initNodes();
			this._initLines();
		}

		// Token: 0x06009F83 RID: 40835 RVA: 0x001FEF04 File Offset: 0x001FD304
		private void _initNodes()
		{
			if (this.leftPart == null || this.rightPart == null)
			{
				return;
			}
			this.nodeList.Clear();
			this.nodeList.Add(new ChampionMatchNode(null, null, null, null));
			for (int i = 1; i <= 30; i++)
			{
				if (i == 1)
				{
					Image component = this.leftPart.Find("Nodes/Icon").GetComponent<Image>();
					this.nodeList.Add(new ChampionMatchNode(null, component, null, null));
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)this.player.playerInfo.occupation, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							this.nodeList[i].SetIcon(tableItem2.IconPath);
						}
					}
					component.gameObject.SetActive(false);
				}
				else if (i == 2)
				{
					Image component2 = this.rightPart.Find("Nodes/Icon").GetComponent<Image>();
					this.nodeList.Add(new ChampionMatchNode(null, component2, null, null));
					this.nodeList[i].SetIcon(ChampionMatchFrame.bossIcon);
					component2.gameObject.SetActive(false);
				}
				else
				{
					Transform transform = this.leftPart.Find("Nodes/Node" + i);
					if (transform == null)
					{
						transform = this.rightPart.Find("Nodes/Node" + i);
					}
					Text component3 = transform.Find("Text").GetComponent<Text>();
					Image component4 = transform.GetComponent<Image>();
					Transform wenhao = transform.Find("Image");
					ChampionMatchNode item = new ChampionMatchNode(component3, null, component4, wenhao);
					this.nodeList.Add(item);
				}
			}
		}

		// Token: 0x06009F84 RID: 40836 RVA: 0x001FF0F4 File Offset: 0x001FD4F4
		private void _initLines()
		{
			if (this.leftPart == null || this.rightPart == null)
			{
				return;
			}
			this.lineList.Clear();
			for (int i = 0; i <= 30; i++)
			{
				if (i < 3)
				{
					this.lineList.Add(new GameObject());
				}
				else
				{
					Transform transform = this.leftPart.Find("Lines/Line" + i);
					if (transform == null)
					{
						transform = this.rightPart.Find("Lines/Line" + i);
					}
					this.lineList.Add(transform.gameObject);
					transform.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06009F85 RID: 40837 RVA: 0x001FF1C0 File Offset: 0x001FD5C0
		private void _showNextPhase()
		{
			ChampionMatchFrame.curPhase++;
			if (ChampionMatchFrame.curPhase >= 1)
			{
				this._setNodesActive(15, 30);
				this.effect1.SetActive(true);
			}
			if (ChampionMatchFrame.curPhase >= 2)
			{
				this._setNodesResult(15, 30);
				this._setNodesActive(7, 14);
				this.effect1.SetActive(false);
				this.effect2.SetActive(true);
			}
			if (ChampionMatchFrame.curPhase >= 3)
			{
				this._setNodesResult(7, 14);
				this._setNodesActive(3, 6);
				this.effect2.SetActive(false);
				this.effect3.SetActive(true);
			}
			if (ChampionMatchFrame.curPhase >= 4)
			{
				this._setNodesResult(3, 6);
				this._setNodesActive(1, 2);
				this.effect3.SetActive(false);
				this.effect4.SetActive(true);
			}
		}

		// Token: 0x06009F86 RID: 40838 RVA: 0x001FF298 File Offset: 0x001FD698
		private void _setNodesActive(int from, int to)
		{
			for (int i = from; i <= to; i++)
			{
				if (this.nodeList[i].name != null)
				{
					this.nodeList[i].SetName(ChampionMatchFrame.matchTree[i]);
				}
				if (ChampionMatchFrame.matchTree[i] == this.player.GetPlayerName())
				{
					this.nodeList[i].SetNameColor(Color.white);
				}
				if (this.nodeList[i].wenhao != null)
				{
					this.nodeList[i].wenhao.gameObject.SetActive(false);
				}
				if (this.nodeList[i].icon != null)
				{
					this.nodeList[i].icon.gameObject.SetActive(true);
					this.dui.gameObject.SetActive(false);
					this.jue.gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x06009F87 RID: 40839 RVA: 0x001FF3B0 File Offset: 0x001FD7B0
		private void _setNodesResult(int from, int to)
		{
			for (int i = from; i <= to; i++)
			{
				this.lineList[i].SetActive(ChampionMatchFrame.lineState[i]);
				if (!ChampionMatchFrame.lineState[i])
				{
					this._setLose(i);
				}
			}
		}

		// Token: 0x06009F88 RID: 40840 RVA: 0x001FF3FC File Offset: 0x001FD7FC
		private void _setLose(int index)
		{
			if (index >= this.nodeList.Count)
			{
				return;
			}
			this.nodeList[index].SetLose();
			this.lineList[index].SetActive(false);
			this._setLose(index * 2 + 1);
			this._setLose(index * 2 + 2);
		}

		// Token: 0x06009F89 RID: 40841 RVA: 0x001FF454 File Offset: 0x001FD854
		protected override void _OnOpenFrame()
		{
			this.battle = (BattleMain.instance.GetBattle() as ChampionMatchBattle);
			this.player = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(0);
			if (!ChampionMatchFrame.inited)
			{
				this._initMatchData();
				ChampionMatchFrame.curPhase = 0;
				ChampionMatchFrame.inited = true;
			}
			if (InputManager.instance != null && !InputManager.instance.isAttackButtonOnly)
			{
				InputManager.instance.SetButtonStateActive(0);
			}
			this._initUIObjects();
			this._showNextPhase();
			if (this.leftAni != null)
			{
				this.leftAni.DORestart(false);
			}
			if (this.rightAni != null)
			{
				this.rightAni.DORestart(false);
			}
			if (this.topAni != null)
			{
				this.topAni.DORestart(false);
			}
			if (this.btnPass != null)
			{
				this.btnPass.gameObject.SetActive(false);
				Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(1500, delegate
				{
					if (this.btnPass != null)
					{
						this.btnPass.gameObject.SetActive(true);
					}
					this.timer = 6f;
				}, 0, 0, false);
			}
		}

		// Token: 0x06009F8A RID: 40842 RVA: 0x001FF578 File Offset: 0x001FD978
		protected override void _OnCloseFrame()
		{
			if (InputManager.instance != null && InputManager.instance.isAttackButtonOnly)
			{
				InputManager.instance.ResetButtonState();
			}
			InputManager.instance.SetEnable(false);
			Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, "UIFlatten/Prefabs/Pk/StartFight", 0f);
			Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(3000, delegate
			{
				InputManager.instance.SetEnable(true);
				if (this.battle != null)
				{
					this.battle.ResumeGameCmd();
				}
			}, 0, 0, false);
		}

		// Token: 0x06009F8B RID: 40843 RVA: 0x001FF5F0 File Offset: 0x001FD9F0
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.timer > 0f)
			{
				this.timer -= timeElapsed;
				if (this.timer < 0f)
				{
					base.Close(false);
					return;
				}
				if (this.txtTimer != null)
				{
					this.txtTimer.text = ((int)this.timer).ToString();
				}
			}
		}

		// Token: 0x040057EC RID: 22508
		public static bool inited;

		// Token: 0x040057ED RID: 22509
		private static string[] matchTree = new string[31];

		// Token: 0x040057EE RID: 22510
		private static bool[] lineState = new bool[31];

		// Token: 0x040057EF RID: 22511
		private static int curPhase = 0;

		// Token: 0x040057F0 RID: 22512
		private static string bossIcon;

		// Token: 0x040057F1 RID: 22513
		private ChampionMatchBattle battle;

		// Token: 0x040057F2 RID: 22514
		private BattlePlayer player;

		// Token: 0x040057F3 RID: 22515
		private int matchRound = 4;

		// Token: 0x040057F4 RID: 22516
		private Button btnPass;

		// Token: 0x040057F5 RID: 22517
		private Text txtTimer;

		// Token: 0x040057F6 RID: 22518
		private Transform leftPart;

		// Token: 0x040057F7 RID: 22519
		private Transform rightPart;

		// Token: 0x040057F8 RID: 22520
		private GameObject dui;

		// Token: 0x040057F9 RID: 22521
		private GameObject jue;

		// Token: 0x040057FA RID: 22522
		private GameObject effect1;

		// Token: 0x040057FB RID: 22523
		private GameObject effect2;

		// Token: 0x040057FC RID: 22524
		private GameObject effect3;

		// Token: 0x040057FD RID: 22525
		private GameObject effect4;

		// Token: 0x040057FE RID: 22526
		private DOTweenAnimation leftAni;

		// Token: 0x040057FF RID: 22527
		private DOTweenAnimation rightAni;

		// Token: 0x04005800 RID: 22528
		private DOTweenAnimation topAni;

		// Token: 0x04005801 RID: 22529
		private List<ChampionMatchNode> nodeList = new List<ChampionMatchNode>();

		// Token: 0x04005802 RID: 22530
		private List<GameObject> lineList = new List<GameObject>();

		// Token: 0x04005803 RID: 22531
		private float timer;
	}
}
