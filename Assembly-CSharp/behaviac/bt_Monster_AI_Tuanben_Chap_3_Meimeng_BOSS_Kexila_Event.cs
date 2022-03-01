using System;

namespace behaviac
{
	// Token: 0x02003955 RID: 14677
	public static class bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event
	{
		// Token: 0x06015A84 RID: 88708 RVA: 0x0068AAC0 File Offset: 0x00688EC0
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Chap_3_Meimeng_BOSS_Kexila_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node1 condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node = new Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node1();
			condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3 condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2 = new Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3();
			condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7 condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3 = new Condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7();
			condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node.SetId(9);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node2.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node10 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node10();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3.SetId(10);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node5.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node11 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node11();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node6.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node7.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node12 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node12();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8.SetId(12);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node8.HasEvents());
			Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4 action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9 = new Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node4();
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_node9.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
