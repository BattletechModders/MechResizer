using BattleTech.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public unsafe void Init (Mech mech, Transform parentTransform, bool isParented)
{
	//IL_0c8c: Unknown result type (might be due to invalid IL)
	//IL_0c9a: Unknown result type (might be due to invalid IL)
	//IL_0c9f: Unknown result type (might be due to invalid IL)
	//IL_0ca4: Unknown result type (might be due to invalid IL)
	base.Init (mech, parentTransform, isParented);
	this.Constants = mech.Combat.Constants;
	bool flag = false;
	this.idleStateEntryHash = Animator.StringToHash ("Base Layer.Idle.Empty");
	this.idleStateFlavorsHash = Animator.StringToHash ("Base Layer.Idle.Flavors");
	this.idleStateUnsteadyHash = Animator.StringToHash ("Base Layer.Idle.Unsteady");
	this.idleStateMeleeBaseHash = Animator.StringToHash ("Base Layer.Idle.Melee Idle");
	this.idleStateMeleeEntryHash = Animator.StringToHash ("Base Layer.Idle.Melee Idle.Empty");
	this.idleStateMeleeHash = Animator.StringToHash ("Base Layer.Idle.Melee Idle.Melee Idle");
	this.idleStateMeleeUnsteadyHash = Animator.StringToHash ("Base Layer.Idle.Melee Idle.Melee Unsteady");
	this.TEMPIdleStateMeleeIdleHash = Animator.StringToHash ("Base Layer.Idle.Melee Idle");
	this.idleRandomValueHash = Animator.StringToHash ("IdleRandom");
	this.standingHash = Animator.StringToHash ("Base Layer.Downed.Getup");
	this.groundDeathIdleHash = Animator.StringToHash ("Base Layer.Death.OnGround Death Idle");
	this.randomDeathIdleA = Animator.StringToHash ("Base Layer.Death.RandomDeath.Death 1");
	this.randomDeathIdleB = Animator.StringToHash ("Base Layer.Death.RandomDeath.Death 2");
	this.randomDeathIdleC = Animator.StringToHash ("Base Layer.Death.RandomDeath.Death 3");
	this.randomDeathIdleBase = Animator.StringToHash ("Base Layer.Death.RandomDeath");
	this.randomDeathIdleRandomizer = Animator.StringToHash ("Base Layer.Death.RandomDeath.Randomize");
	this.hitReactLightHash = Animator.StringToHash ("Base Layer.Hit React.Hit React Light");
	this.hitReactHeavyHash = Animator.StringToHash ("Base Layer.Hit React.Hit React Stagger");
	this.hitReactMeleeHash = Animator.StringToHash ("Base Layer.Hit React.Hit React Melee");
	this.hitReactDodgeHash = Animator.StringToHash ("Base Layer.Hit React.Melee Dodge");
	this.hitReactDFAHash = Animator.StringToHash ("Base Layer.Hit React.DFA");
	this.allowRandomIdles = true;
	this.SetIdleAnimState ();
	base.thisAnimator.Play (this.idleStateFlavorsHash, 0, UnityEngine.Random.Range (0f, 1f));
	this.IsOnLimpingLeg = false;
	this.HasCalledOutLimping = false;
	this.isJumping = false;
	this.isPlayingJumpSound = false;
	this.persistentCritList = new List<string> (this.Constants.VFXNames.persistentCritNames);
	if ((UnityEngine.Object)base.twistTransform == (UnityEngine.Object)null) {
		flag = true;
		base.twistTransform = base.findRecursive (base.transform, "j_Spine2");
		if ((UnityEngine.Object)base.twistTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup twistTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.LeftArmAttach == (UnityEngine.Object)null) {
		flag = true;
		this.LeftArmAttach = base.findRecursive (base.transform, "j_LForearm");
		if ((UnityEngine.Object)this.LeftArmAttach == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup LeftArmAttach for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.RightArmAttach == (UnityEngine.Object)null) {
		flag = true;
		this.RightArmAttach = base.findRecursive (base.transform, "j_RForearm");
		if ((UnityEngine.Object)this.RightArmAttach == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup RightArmAttach for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.TorsoAttach == (UnityEngine.Object)null) {
		flag = true;
		this.TorsoAttach = base.findRecursive (base.transform, "j_Spine2");
		if ((UnityEngine.Object)this.TorsoAttach == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup TorsoAttach for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.LeftLegAttach == (UnityEngine.Object)null) {
		flag = true;
		this.LeftLegAttach = base.findRecursive (base.transform, "j_LCalf");
		if ((UnityEngine.Object)this.LeftLegAttach == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup LeftLegAttach for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.leftFootTransform == (UnityEngine.Object)null) {
		flag = true;
		this.leftFootTransform = base.findRecursive (base.transform, "j_LHeel");
		if ((UnityEngine.Object)this.leftFootTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup leftFootTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.RightLegAttach == (UnityEngine.Object)null) {
		flag = true;
		this.RightLegAttach = base.findRecursive (base.transform, "j_RCalf");
		if ((UnityEngine.Object)this.RightLegAttach == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup RightLegAttach for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.rightFootTransform == (UnityEngine.Object)null) {
		flag = true;
		this.rightFootTransform = base.findRecursive (base.transform, "j_RHeel");
		if ((UnityEngine.Object)this.rightFootTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup rightFootTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxCenterTorsoTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxCenterTorsoTransform = base.twistTransform;
		if ((UnityEngine.Object)this.vfxCenterTorsoTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxCenterTorsoTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxLeftArmTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxLeftArmTransform = this.LeftArmAttach;
		if ((UnityEngine.Object)this.vfxLeftArmTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxLeftArmTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxRightArmTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxRightArmTransform = this.RightArmAttach;
		if ((UnityEngine.Object)this.vfxRightArmTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxRightArmTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxHeadTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxHeadTransform = base.twistTransform;
		if ((UnityEngine.Object)this.vfxHeadTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxHeadTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxLeftArmTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxLeftArmTransform = this.LeftArmAttach;
		if ((UnityEngine.Object)this.vfxLeftArmTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxLeftArmTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxRightArmTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxRightArmTransform = this.RightArmAttach;
		if ((UnityEngine.Object)this.vfxRightArmTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxRightArmTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxLeftLegTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxLeftLegTransform = this.LeftLegAttach;
		if ((UnityEngine.Object)this.vfxLeftLegTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxLeftLegTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.vfxRightLegTransform == (UnityEngine.Object)null) {
		flag = true;
		this.vfxRightLegTransform = this.RightLegAttach;
		if ((UnityEngine.Object)this.vfxRightLegTransform == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup vfxRightLegTransform for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)base.BlipObjectUnknown == (UnityEngine.Object)null) {
		flag = true;
		Transform transform = base.findRecursive (base.transform, "BlipObjectUnknown");
		if ((UnityEngine.Object)transform != (UnityEngine.Object)null) {
			base.BlipObjectUnknown = transform.gameObject;
		}
		if ((UnityEngine.Object)base.BlipObjectUnknown == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup Unknown Blip for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)base.BlipObjectIdentified == (UnityEngine.Object)null) {
		flag = true;
		Transform transform2 = base.findRecursive (base.transform, "BlipObjectIdentified");
		if ((UnityEngine.Object)transform2 != (UnityEngine.Object)null) {
			base.BlipObjectIdentified = transform2.gameObject;
		}
		if ((UnityEngine.Object)base.BlipObjectIdentified == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup Identified Blip for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.headDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform3 = base.findRecursive (base.transform, "Head_whole");
		if ((UnityEngine.Object)transform3 != (UnityEngine.Object)null) {
			this.headDestructible = ((Component)transform3).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.headDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup headDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.centerTorsoDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform4 = base.findRecursive (base.transform, "torso_whole");
		if ((UnityEngine.Object)transform4 != (UnityEngine.Object)null) {
			this.centerTorsoDestructible = ((Component)transform4).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.centerTorsoDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup centerTorsoDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.leftTorsoDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform5 = base.findRecursive (base.transform, "lefttorso_whole");
		if ((UnityEngine.Object)transform5 != (UnityEngine.Object)null) {
			this.leftTorsoDestructible = ((Component)transform5).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.leftTorsoDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup leftTorsoDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.rightTorsoDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform6 = base.findRecursive (base.transform, "righttorso_whole");
		if ((UnityEngine.Object)transform6 != (UnityEngine.Object)null) {
			this.rightTorsoDestructible = ((Component)transform6).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.rightTorsoDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup rightTorsoDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.leftArmDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform7 = base.findRecursive (base.transform, "LArm_whole");
		if ((UnityEngine.Object)transform7 != (UnityEngine.Object)null) {
			this.leftArmDestructible = ((Component)transform7).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.leftArmDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup leftArmDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.rightArmDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform8 = base.findRecursive (base.transform, "RArm_whole");
		if ((UnityEngine.Object)transform8 != (UnityEngine.Object)null) {
			this.rightArmDestructible = ((Component)transform8).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.rightArmDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup rightArmDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.leftLegDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform9 = base.findRecursive (base.transform, "LLeg_whole");
		if ((UnityEngine.Object)transform9 != (UnityEngine.Object)null) {
			this.leftLegDestructible = ((Component)transform9).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.leftLegDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup leftLegDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)this.rightLegDestructible == (UnityEngine.Object)null) {
		flag = true;
		Transform transform10 = base.findRecursive (base.transform, "RLeg_whole");
		if ((UnityEngine.Object)transform10 != (UnityEngine.Object)null) {
			this.rightLegDestructible = ((Component)transform10).GetComponent<MechDestructibleObject> ();
		}
		if ((UnityEngine.Object)this.rightLegDestructible == (UnityEngine.Object)null) {
			Debug.LogWarning ("ERROR! Couldn't auto-setup rightLegDestructible for mech " + this.parentMech.DisplayName);
		}
	}
	if ((UnityEngine.Object)base.VisibleObject == (UnityEngine.Object)null) {
		Debug.LogError ("================= ERROR! Mech " + this.parentMech.DisplayName + " has no visible object!!! FIX THIS ======================");
	} else {
		this.mechMerge = base.gameObject.AddComponent<MechMeshMerge> ();
	}
	if (flag) {
		Debug.LogError ("================== ERROR! Found missing transforms in mech " + this.parentMech.DisplayName + "; auto-settings are going to look wrong! FIX THIS ============");
	}
	if ((UnityEngine.Object)base.audioObject == (UnityEngine.Object)null) {
		Debug.LogError ("================= ERROR! Mech " + this.parentMech.DisplayName + " has no audio object!!! FIX THIS ======================");
	}
	if ((UnityEngine.Object)base.audioObject != (UnityEngine.Object)null) {
		AudioSwitch_mech_weight_type switchEnumValue = AudioSwitch_mech_weight_type.b_medium;
		switch (this.parentMech.MechDef.Chassis.weightClass) {
		case WeightClass.LIGHT:
			switchEnumValue = AudioSwitch_mech_weight_type.a_light;
			break;
		case WeightClass.MEDIUM:
			switchEnumValue = AudioSwitch_mech_weight_type.b_medium;
			break;
		case WeightClass.HEAVY:
			switchEnumValue = AudioSwitch_mech_weight_type.c_heavy;
			break;
		case WeightClass.ASSAULT:
			switchEnumValue = AudioSwitch_mech_weight_type.d_assault;
			break;
		}
		WwiseManager.SetSwitch (switchEnumValue, base.audioObject);
		if (this.useBirdFoot) {
			WwiseManager.SetSwitch (AudioSwitch_mech_foot_type.bird, base.audioObject);
		} else {
			WwiseManager.SetSwitch (AudioSwitch_mech_foot_type.human, base.audioObject);
		}
		WwiseManager.SetRTPC (AudioRTPCList.bt_heeltoe_delay, 100f - mech.tonnage, base.audioObject);
		WwiseManager.SetRTPC (AudioRTPCList.bt_vehicle_speed, 0f, base.audioObject);
		WwiseManager.SetSwitch (AudioSwitch_mech_engine_damaged_mildly_yesno.damaged_mildly_no, base.audioObject);
		WwiseManager.SetSwitch (AudioSwitch_mech_engine_damaged_badly_yesno.damaged_badly_no, base.audioObject);
	}
	MechComponentRef[] inventory = mech.MechDef.Inventory;
	if (MechRepresentation.<>f__am$cache0 == (Func)0) {
		MechRepresentation.<>f__am$cache0 = new Func ((object)null, (IntPtr)(void*)/*OpCode not supported: LdFtn*/);
	}
	int num = inventory.Where (MechRepresentation.<>f__am$cache0).Count ();
	if (num > 0) {
		this.SetupJumpJets (mech, mech.MechDef, mech.Combat.DataManager);
		mech.Combat.DataManager.PrecachePrefab ("JumpjetCurves", BattleTechResourceType.Prefab, num);
	}
	string id = string.Format ("chrPrfComp_{0}_centertorso_headlight", mech.MechDef.Chassis.PrefabBase);
	string id2 = string.Format ("chrPrfComp_{0}_leftshoulder_headlight", mech.MechDef.Chassis.PrefabBase);
	string id3 = string.Format ("chrPrfComp_{0}_rightshoulder_headlight", mech.MechDef.Chassis.PrefabBase);
	this.headlightReps.Clear ();
	GameObject gameObject = mech.Combat.DataManager.PooledInstantiate (id, BattleTechResourceType.Prefab, null, null, null);
	if ((UnityEngine.Object)gameObject != (UnityEngine.Object)null) {
		gameObject.transform.parent = this.vfxHeadTransform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		this.headlightReps.Add (gameObject);
	}
	gameObject = mech.Combat.DataManager.PooledInstantiate (id2, BattleTechResourceType.Prefab, null, null, null);
	if ((UnityEngine.Object)gameObject != (UnityEngine.Object)null) {
		gameObject.transform.parent = this.vfxLeftShoulderTransform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		this.headlightReps.Add (gameObject);
	}
	gameObject = mech.Combat.DataManager.PooledInstantiate (id3, BattleTechResourceType.Prefab, null, null, null);
	if ((UnityEngine.Object)gameObject != (UnityEngine.Object)null) {
		gameObject.transform.parent = this.vfxRightShoulderTransform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		this.headlightReps.Add (gameObject);
	}
	this.RefreshSurfaceType (true);
	base.InitHighlighting ();
	base.InitWindZone ();
	this.parentMech.Combat.MessageCenter.AddSubscriber (MessageCenterMessageType.OnHeatChanged, this.OnHeatChanged);
	this.heatAmount = new PropertyBlockManager.PropertySetting ("_Heat", 0f);
	base.propertyBlock.AddProperty (ref this.heatAmount);
	CombatValueMultipliersDef combatValueMultipliers = this.Constants.CombatValueMultipliers;
	float tEST_MechScaleMultiplier = combatValueMultipliers.TEST_MechScaleMultiplier;
	base.thisTransform.localScale = new Vector3 (tEST_MechScaleMultiplier, tEST_MechScaleMultiplier, tEST_MechScaleMultiplier);
	Animator component = base.GetComponent<Animator> ();
	component.cullingMode = AnimatorCullingMode.AlwaysAnimate;
	base.gameObject.AddComponent<ShadowTracker> ();
	this.SetupDamageStates (mech, mech.MechDef);
	this.mechMerge.RefreshCombinedMesh (true);
}
