#!/bin/bash

# Script to create and push a release tag for Translumo
# This will automatically trigger the release workflow on GitHub

set -e  # Exit on error

echo "🚀 Translumo Release Creator"
echo "============================"
echo ""

# Get current version from AssemblyInfo.cs
VERSION="1.0.2"
TAG="v${VERSION}"

echo "📌 Version: ${VERSION}"
echo "🏷️  Tag: ${TAG}"
echo ""

# Check if we're in the right directory
if [ ! -f "Translumo.sln" ]; then
    echo "❌ Error: This script must be run from the Translumo repository root"
    exit 1
fi

# Check if tag already exists locally
if git rev-parse "${TAG}" >/dev/null 2>&1; then
    echo "⚠️  Tag ${TAG} already exists locally"
    read -p "Do you want to delete and recreate it? (y/N) " -n 1 -r
    echo ""
    if [[ $REPLY =~ ^[Yy]$ ]]; then
        git tag -d "${TAG}"
        echo "✓ Deleted local tag ${TAG}"
    else
        echo "❌ Aborted"
        exit 1
    fi
fi

# Check if tag exists on remote
if git ls-remote --tags origin | grep -q "refs/tags/${TAG}"; then
    echo "⚠️  Tag ${TAG} already exists on GitHub"
    read -p "Do you want to delete and recreate it? (y/N) " -n 1 -r
    echo ""
    if [[ $REPLY =~ ^[Yy]$ ]]; then
        git push --delete origin "${TAG}"
        echo "✓ Deleted remote tag ${TAG}"
    else
        echo "❌ Aborted"
        exit 1
    fi
fi

# Make sure we're up to date
echo "📥 Pulling latest changes..."
git pull origin master || git pull origin main || true

# Create the tag
echo "🏷️  Creating tag ${TAG}..."
git tag -a "${TAG}" -m "Release version ${VERSION} with multimodal translation support"
echo "✓ Tag created"

# Push the tag
echo "📤 Pushing tag to GitHub..."
git push origin "${TAG}"
echo "✓ Tag pushed"

echo ""
echo "✅ Success! Release workflow has been triggered."
echo ""
echo "📊 Monitor the workflow at:"
echo "   https://github.com/mimomi666/Translumo/actions"
echo ""
echo "📦 Once complete, the release will be available at:"
echo "   https://github.com/mimomi666/Translumo/releases"
echo ""
echo "⏱️  Expected completion time: 5-10 minutes"
echo ""
