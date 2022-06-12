using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;
using TMPro;

namespace UnityEngine.XR.ARFoundation.Samples
{
	/// <summary>
	/// Listens for touch events and performs an AR raycast from the screen touch point.
	/// AR raycasts will only hit detected trackables like feature points and planes.
	///
	/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
	/// and moved to the hit position.
	/// </summary>
	[RequireComponent(typeof(ARRaycastManager))]
	public class PlaceOnPlane : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Instantiates this prefab on a plane at the touch location.")]
		GameObject m_PlacedPrefab;

		/// <summary>
		/// The prefab to instantiate on touch.
		/// </summary>
		public GameObject placedPrefab
		{
			get { return m_PlacedPrefab; }
			set { m_PlacedPrefab = value; }
		}

		/// <summary>
		/// The object instantiated as a result of a successful raycast intersection with a plane.
		/// </summary>
		public GameObject[] spawnedObject;
		private bool hitCheck = false;
		private Vector2 planeSize = new PlaneSelection().planeSize;
		private int nbInstances = 0;

		void Awake()
		{
			m_RaycastManager = GetComponent<ARRaycastManager>();
		}

		bool TryGetTouchPosition(out Vector2 touchPosition)
		{
			if (Input.touchCount > 0)
			{
				touchPosition = Input.GetTouch(0).position;
				return true;
			}

			touchPosition = default;
			return false;
		}

		void Update()
		{
			Vector3 prefabOnPlane = new Vector3(Random.Range(-planeSize.x, planeSize.x), 0.1f, Random.Range(-planeSize.y, planeSize.y));

			if (!TryGetTouchPosition(out Vector2 touchPosition))
				return;

			if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
			{
				// Raycast hits are sorted by distance, so the first one
				// will be the closest hit.
				//var hitPose = s_Hits[0].pose;

				Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(cameraRay, out RaycastHit hitInfo))
				{
					if (hitInfo.collider.CompareTag("Plane") && hitCheck == false)
					{
						hitCheck = true;
					}
				}

				for (int i = 0; i < spawnedObject.Length; i++)
				{
					spawnedObject[i] = Instantiate(m_PlacedPrefab, hitInfo.collider.gameObject.transform.position + prefabOnPlane, hitInfo.collider.gameObject.transform.rotation);
					//PlaneDetectionUI.Instance.nombreInstances.text = (i + 1).ToString();
				}
			}
		}

		static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

		ARRaycastManager m_RaycastManager;
	}
}
