using System;

namespace behaviac
{
	// Token: 0x020038A8 RID: 14504
	public static class bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event
	{
		// Token: 0x06015932 RID: 88370 RVA: 0x006834F4 File Offset: 0x006818F4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_3_Emeng_BOSS_Kexila_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node11 parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node = new Parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node11();
			parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetId(11);
			bt.AddChild(parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(12);
			parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node13 condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node = new Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node13();
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetId(13);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node14 condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2 = new Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node14();
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2.SetId(14);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node15 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node15();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetId(15);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node0 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node0();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4.SetId(0);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node16 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node16();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5.SetId(16);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(17);
			parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node18 condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3 = new Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node18();
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3.SetId(18);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node3.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node19 condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4 = new Condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node19();
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4.SetId(19);
			sequence2.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node6 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node4();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node6.SetId(4);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node6.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node7 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node5();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node7.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node7.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node20 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node8 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node20();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node8.SetId(20);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node8);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node8.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node1 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node9 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node1();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node9.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node9.SetId(1);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node9);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node9.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node21 action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node10 = new Action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node21();
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node10.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node10.SetId(21);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node10);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node10.HasEvents());
			parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.SetHasEvents(parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_Tuanben_Chap_3_Emeng_BOSS_Kexila_Event_node.HasEvents());
			return true;
		}
	}
}
