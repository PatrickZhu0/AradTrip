using System;

namespace behaviac
{
	// Token: 0x0200332B RID: 13099
	public static class bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event
	{
		// Token: 0x06014EBC RID: 85692 RVA: 0x0064DA18 File Offset: 0x0064BE18
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Goblin_gebulinwang_diushaizi_Event");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(6);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node9 action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node = new Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node9();
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.SetId(9);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.HasEvents());
			Assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node5 assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node = new Assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node5();
			assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.SetId(5);
			sequence.AddChild(assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(7);
			selector.AddChild(sequence2);
			Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node24 action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node24();
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2.SetId(24);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node8 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node8();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node1 condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node1();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4.SetId(1);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node4.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2 action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node2();
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3.SetId(2);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_gebulinwang_diushaizi_Event_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
