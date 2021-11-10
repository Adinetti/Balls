using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace BallsGame.Views {
    public class MeshCreator {
        private static readonly int CORNERS_COUNT = 32;
        private static readonly float RADIUS = 0.5f;
        private static readonly float TAU = Mathf.PI * 2;
        private static Mesh _mesh;

        public static Mesh Create() {
            if (_mesh == null) {
                _mesh = new Mesh();
                _mesh.vertices = CreateVertices();
                _mesh.triangles = CreateTriangles();
                _mesh.name = "ball_mesh";
                _mesh.RecalculateNormals();
            }
            return _mesh;
        }

        private static Vector3[] CreateVertices() {
            var vertices = new Vector3[CORNERS_COUNT + 1];
            vertices[0] = Vector3.zero;
            for (int i = 0; i < CORNERS_COUNT; i++) {
                var angle = i * TAU / CORNERS_COUNT;
                var xPos = RADIUS * Mathf.Cos(angle);
                var yPos = RADIUS * Mathf.Sin(angle);
                vertices[i + 1] = new Vector3(xPos, yPos, 0);
            }
            return vertices;
        }

        private static int[] CreateTriangles() {
            var triangles = new int[CORNERS_COUNT * 3];
            var vertix = 1;
            for (int t = 0; t < CORNERS_COUNT; t++) {
                var id = t * 3;
                triangles[id] = 0;
                triangles[id + 1] = t < CORNERS_COUNT - 1 ? (vertix + 1) : 1;
                triangles[id + 2] = vertix;
                vertix = triangles[id + 1];
            }
            return triangles;
        }
    }
}


