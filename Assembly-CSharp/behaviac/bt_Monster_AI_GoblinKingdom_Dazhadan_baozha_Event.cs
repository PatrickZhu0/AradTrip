using System;

namespace behaviac
{
	// Token: 0x020032D9 RID: 13017
	public static class bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event
	{
		// Token: 0x06014E22 RID: 85538 RVA: 0x0064ACE8 File Offset: 0x006490E8
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Dazhadan_baozha_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node5 action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node = new Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node5();
			action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2 action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2 = new Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2();
			action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
