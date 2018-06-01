using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip[] audioClips;
    private AudioSource source;
    private Bumper[] players;
    private Ball ball;

    void Start() {
        source = GetComponent<AudioSource>();
        ball = FindObjectOfType<Ball>();
        players = FindObjectsOfType<Bumper>();
        ball.PassedThroughRing += PointScored;
        ball.StoppedMoving += PointScored;
        ball.TouchedWall += TouchedWall;
        players.ToList().ForEach(x => x.TouchedMiddleLine += PointsScored);
        players.ToList().ForEach(x => x.TouchedBall += BumperTouchedBall);
    }

    private void TouchedWall() {
        PlayAudio(1);
    }

    private void BumperTouchedBall() {
        PlayAudio(0);
    }

    private void PointsScored(GameObject obj) {
        PlayAudio(2);
    }

    private void PointScored(object sender, BallEventArgs e) {
        PlayAudio(2);
    }

    private void PlayAudio(int clip) {
        source.clip = audioClips[clip];
        if (!source.isPlaying)
            source.Play();
    }
}
