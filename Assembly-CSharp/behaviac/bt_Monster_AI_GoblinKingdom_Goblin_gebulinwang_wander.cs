using System;

namespace behaviac
{
	// Token: 0x02003332 RID: 13106
	public static class bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander
	{
		// Token: 0x06014EC9 RID: 85705 RVA: 0x0064DE7C File Offset: 0x0064C27C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Goblin_gebulinwang_wander");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node7 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node7();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2 action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node = new Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2();
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node8 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node3 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node8();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node3.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node3.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node5 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node5();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node4.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node6 action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node6();
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_wander_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
