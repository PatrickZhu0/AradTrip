using System;

namespace behaviac
{
	// Token: 0x02003322 RID: 13090
	public static class bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander
	{
		// Token: 0x06014EAB RID: 85675 RVA: 0x0064D380 File Offset: 0x0064B780
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Goblin_fengkuangchushi_wander");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(2);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2.SetId(5);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4 action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node = new Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4();
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(3);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node9 action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node9();
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(11);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node16 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node16();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5.SetId(16);
			sequence3.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node12 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node12();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6.SetId(12);
			sequence3.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node6.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node10 action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node10();
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3.SetId(10);
			sequence3.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			Sequence sequence4 = new Sequence();
			sequence4.SetClassNameString("Sequence");
			sequence4.SetId(13);
			selector.AddChild(sequence4);
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node17 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node17();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7.SetId(17);
			sequence4.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node7.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node14 condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node14();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8.SetId(14);
			sequence4.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8);
			sequence4.SetHasEvents(sequence4.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node8.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node15 action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node15();
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4.SetId(15);
			sequence4.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4);
			sequence4.SetHasEvents(sequence4.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node4.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence4.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node1 action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node1();
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5.SetId(1);
			selector.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5);
			selector.SetHasEvents(selector.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_fengkuangchushi_wander_node5.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
