/////////////////////////////////////////////////////////////////////////////////
//
//	vp_PlayerRespawner.cs
//	© VisionPunk. All Rights Reserved.
//	https://twitter.com/VisionPunk
//	http://www.visionpunk.com
//
//	description:	this is an implementation of vp_Respawner that is aware of
//					the player event handler, for the purpose of accessing its
//					Position, Rotation and Stop events
//
/////////////////////////////////////////////////////////////////////////////////
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class vp_PlayerRespawner : vp_Respawner
{
	public List<GameObject> ObjectsToReinstantiate;
	private vp_PlayerEventHandler m_Player = null;	// should never be referenced directly
	protected vp_PlayerEventHandler Player {	// lazy initialization of the event handler field
		get {
			if (m_Player == null)
				m_Player = transform.GetComponent<vp_PlayerEventHandler> ();
			return m_Player;
		}
	}


	/// <summary>
	/// 
	/// </summary>
	protected override void Awake ()
	{

		base.Awake ();

	}


	/// <summary>
	/// registers this component with the event handler (if any)
	/// </summary>
	protected override void OnEnable ()
	{

		if (Player != null)
			Player.Register (this);

		base.OnEnable ();

	}


	/// <summary>
	/// unregisters this component from the event handler (if any)
	/// </summary>
	protected override void OnDisable ()
	{
	
		if (Player != null)
			Player.Unregister (this);

	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (1)) {
			IsClone = !IsClone;
		}

	}


	/// <summary>
	/// event target. resets position, angle and motion
	/// </summary>
	public override void Reset ()
	{

		if (!Application.isPlaying)
			return;

		if (Player == null)
			return;

		//List of objects that we want to reinstantiate
		//Code will have to be written for each type
		if (ObjectsToReinstantiate != null) {
			foreach (GameObject ListofObjs in ObjectsToReinstantiate) {
				foreach (Transform obj in ListofObjs.transform) {
					
					//Reinstantiate Crumbling Platforms under the object
					if(obj.tag == "Platform"){
						TransparentCrumblingFloors platform = obj.Find ("GlassPane_Plane_Material.004").gameObject.GetComponent<TransparentCrumblingFloors> ();
						platform.renderer.enabled = true;
						platform.collider.enabled = true;
						platform.transform.parent.Find ("Edges_Cylinder_Material.005").transform.renderer.enabled = true;
						platform.transform.parent.Find ("Sphere_Sphere_Material.006").transform.renderer.enabled = true;
						platform.transform.parent.collider.enabled = true;
						platform.timer = platform.GetTimerMax ();
						platform.respawnTimer = platform.GetRespawnTimerMax ();
					}
					
					else if(obj.tag == "MainCube") //if(obj.Find("PowerCube Main").gameObject.GetComponent<PowerCube>() != null)
					{
						PowerCube p = obj.gameObject.GetComponent<PowerCube>();
						p.Reset();
						
					}
					
					else if(ListofObjs.tag == "Poison"){
						ListofObjs.GetComponent<PoisonFog>().canKill = 1;
						
					}
					
					else if(ListofObjs.tag == "Bullets"){
						var bulletList = GameObject.FindGameObjectsWithTag("bullet");
						foreach(GameObject b in bulletList){
							b.GetComponent<projectileScript>().canKill = 1;
						}
					}
					
				}
			}
		}

		//if(IsClone)
		//	Player.GetComponent<CharacterSwap>().Swap();

		IsClone = false;

		if (ClonePlacement == null)
			Clone.transform.position = CloneSpawn.transform.position;
		else
			Clone.transform.position = ClonePlacement.Position;

		Player.Position.Set (Placement.Position);
		Player.Rotation.Set (Placement.Rotation.eulerAngles);
		Player.Stop.Send ();

	}


}