using UnityEngine;
using System;
using System.Collections;
using Random = UnityEngine.Random;

namespace CaveSounds
{
    public class CaveSoundManager : MonoBehaviour
    {
        static bool canPlaySounds = true;
        static GameObject cave;
        static AudioSource caveSoundSource;
        public void Start()
        {
            caveSoundSource = gameObject.AddComponent<AudioSource>();
            caveSoundSource.minDistance = 20;
            cave = GameObject.Find("/Level/cave");
        }

        public void Update()
        {
            gameObject.transform.position = GorillaLocomotion.Player.Instance.headCollider.transform.position;
            if (canPlaySounds)
            {
                canPlaySounds = false;
                StartCoroutine(PlayRandomSound());
            }
        }

        IEnumerator PlayRandomSound()
        {
            int waitForThisLong = 30 * Random.Range(1, 4);
            yield return new WaitForSeconds(waitForThisLong);

            bool canPlay = cave.activeInHierarchy;
            if (canPlay)
            {
                int randomChild = Random.Range(0, gameObject.transform.childCount);
                GameObject obj = gameObject.transform.GetChild(randomChild).gameObject;
                AudioClip clip = obj.GetComponent<AudioSource>().clip;
                caveSoundSource.PlayOneShot(clip, 0.5f);
                yield return new WaitForSeconds(clip.length);
            }
            canPlaySounds = true;
        }
    }
}
